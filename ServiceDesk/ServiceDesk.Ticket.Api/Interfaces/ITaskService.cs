using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasks();
        Task<TaskDto> GetTask(Guid id);
        Task CreateTask(TaskDto taskDto);
        Task DeleteTask(Guid id);
        Task UpdateTask(Guid id, TaskDto taskDto);
    }
}
