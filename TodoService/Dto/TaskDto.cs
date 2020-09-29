using System;
using System.ComponentModel.DataAnnotations;

namespace TodoService.Dto
{
    /// <summary>
    /// Информация о задаче.
    /// </summary>
    public sealed class TaskDto
    {
        /// <summary>
        /// Текущий статус.
        /// </summary>
        [Required]
        public string Status { get; set; } = default!;

        /// <summary>
        /// Последнее время изменения статуса.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}