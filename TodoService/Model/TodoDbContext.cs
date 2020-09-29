using Microsoft.EntityFrameworkCore;

namespace TodoService.Model
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    public class TodoDbContext : DbContext
    {
        /// <summary>
        /// Задачи.
        /// </summary>
        public DbSet<TodoTask> Tasks { get; set; } = default!;

        /// <summary>
        /// Статусы задач.
        /// </summary>
        public DbSet<TodoTaskStatus> Statuses { get; set; } = default!;

        /// <summary>
        /// Конструктор <see cref="TodoDbContext"/>.
        /// </summary>
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }
    }
}