using System;

namespace TodoService.Model
{
    /// <summary>
    /// Задача.
    /// </summary>
    public class TodoTask
    {
        /// <summary>
        /// `GUID` задачи.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        public TodoTaskStatus Status { get; set; } = default!;

        /// <summary>
        /// Последнее время изменения статуса.
        /// </summary>
        public DateTime StatusChangeDateTime { get; set; }
    }
}