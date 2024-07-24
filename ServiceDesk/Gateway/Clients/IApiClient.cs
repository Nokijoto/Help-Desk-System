using Gateway.Storage.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Clients
{
    public interface IApiClient<TDto> where TDto : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task AddAsync(TDto dto);
        Task AddNoteAsync(Guid id, TDto dto);
        Task AddTaskAsync(Guid id, TDto dto);
        Task AddElementAsync(Guid id, TDto dto);
        Task UpdateAsync(Guid id, TDto dto);
        Task UpdateAssigneeAsync(Guid id, TDto dto);
        Task UpdateStatusAsync(Guid id, TDto dto);
        Task UpdatePriorityAsync(Guid id, TDto dto);
        Task UpdateNoteAsync(Guid id, TDto dto);
        Task UpdateTaskAsync(Guid id, TDto dto);
        Task DeleteAsync(Guid id);
        Task CreateAsync(TDto dto);
        Task<IEnumerable<TDto>> GetAllAsyncTicket();
        Task<TDto> GetByIdAsyncTicket(Guid id);
        Task<IEnumerable<AssetDto>> GetByIdElementAsync(Guid id);
        Task UpdateAsynccc(Guid id, TDto dto);
    }
}
