namespace TodoService.Entities
{
    /// <summary>
    /// Статус задачи.
    /// </summary>
    public enum TaskStatuses
    {
        /// <summary>
        /// Создана.
        /// </summary>
        Created = 1,

        /// <summary>
        /// Запущена.
        /// </summary>
        Running = 2,

        /// <summary>
        /// Завершена.
        /// </summary>
        Finished = 3,
    }
}