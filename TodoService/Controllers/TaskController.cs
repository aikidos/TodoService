using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoService.Services;

namespace TodoService.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        /// <summary>
        /// Конструктор <see cref="TaskController"/>.
        /// </summary>
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        /// <summary>
        /// Создаёт новую задачу.
        /// </summary>
        /// <response code="202">`GUID` созданной задачи.</response>
        [HttpPost]
        public async Task<ActionResult> Create()
        {
            var taskGuid = await _service.CreateTaskAsync();

            return Accepted(taskGuid);
        }

        /// <summary>
        /// Возвращает информацию о задаче.
        /// </summary>
        /// <param name="id">`GUID` задачи.</param>
        /// <response code="200">Информация о задаче.</response>
        /// <response code="404">Задача с указанным `GUID` не найдена.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var task = await _service.GetTaskAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}