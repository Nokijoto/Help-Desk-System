using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasks();
        Task<TaskDto> GetTask(Guid id);
        Task CreateTask(Guid ticketId, CreateTaskDto taskDto);
        Task DeleteTask(Guid id);
        Task UpdateTask(Guid id, CreateTaskDto taskDto);
    }
}
