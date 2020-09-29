using System;
using System.Threading.Tasks;
using TodoService.Dto;

namespace TodoService.Services
{
    /// <summary>
    /// Сервис для работы с задачами.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Создаёт новую задачу и возвращает её `GUID`.
        /// </summary>
        Task<Guid> CreateTaskAsync();

        /// <summary>
        /// Возвращает задачу.
        /// `NULL`, если задача не найдена.
        /// </summary>
        /// <param name="guid">`GUID` задачи.</param>
        Task<TaskDto?> GetTaskAsync(Guid guid);
    }
}