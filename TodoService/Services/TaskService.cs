using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoService.Dto;
using TodoService.Entities;
using TodoService.Model;

namespace TodoService.Services
{
    /// <inheritdoc />
    public sealed class TaskService : ITaskService
    {
        private readonly TodoDbContext _context;
        private Dictionary<TaskStatuses, TodoTaskStatus>? _statusById;

        /// <summary>
        /// Конструктор <see cref="TaskService"/>.
        /// </summary>
        public TaskService(TodoDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Guid> CreateTaskAsync()
        {
            _statusById ??= await _context.Statuses
                .ToDictionaryAsync(status => (TaskStatuses)status.Id);

            var task = new TodoTask
            {
                Id = Guid.NewGuid(),
                Status = _statusById[TaskStatuses.Created],
                StatusChangeDateTime = DateTime.Now,
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            // Эмуляция работы (2 минуты ожидания)
            _ = ChangeStatusAsync(task, TaskStatuses.Running)
                .ContinueWith(_ => Task.Delay(TimeSpan.FromMinutes(2)))
                .Unwrap()
                .ContinueWith(_ => ChangeStatusAsync(task, TaskStatuses.Finished))
                .Unwrap();

            return task.Id;
        }

        /// <inheritdoc />
        public async Task<TaskDto?> GetTaskAsync(Guid guid)
        {
            var task = await _context.Tasks
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.Id == guid);

            if (task == null)
            {
                return null;
            }

            return new TaskDto
            {
                Status = task.Status.Name,
                Timestamp = task.StatusChangeDateTime,
            };
        }

        private async Task ChangeStatusAsync(TodoTask task, TaskStatuses status)
        {
            task.Status = _statusById![status];
            task.StatusChangeDateTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}