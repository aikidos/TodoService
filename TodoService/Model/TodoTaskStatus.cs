using System.Collections.Generic;

namespace TodoService.Model
{
    /// <summary>
    /// Статус задачи.
    /// </summary>
    public class TodoTaskStatus
    {
        /// <summary>
        /// Идентификатор статуса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование статуса.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Задачи с данным статусом.
        /// </summary>
        public ICollection<TodoTask>? Tasks { get; set; }
    }
}