using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService=taskService;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            return await _taskService.GetTasks();
        }

        [HttpGet("{id}")]
        public async Task<TaskDto> GetTask(Guid id)
        {
            return await _taskService.GetTask(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDto taskDto)
        {
            await _taskService.CreateTask(taskDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task DeleteTask(Guid id)
        {
            await _taskService.DeleteTask(id);
        }
        [HttpPut("{id}")]
        public async Task UpdateTask(Guid id, TaskDto taskDto)
        {
            await _taskService.UpdateTask(id, taskDto);
        }
    }
}
