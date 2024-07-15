using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api.Services
{
    public class TaskService: ITaskService
    {
        private readonly TicketDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(TicketDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTask(Guid id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<TaskDto>(task);
        }
        

       public async Task CreateTask(TaskDto taskDto)
        {
            var task = _mapper.Map<Storage.Entities.Task>(taskDto);
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTask(Guid id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTask(Guid id, TaskDto taskDto)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task is null)
            {
                throw new Exception("Task not found");
            }
            _mapper.Map(taskDto, task);
            await _dbContext.SaveChangesAsync();
        }
    }
}
