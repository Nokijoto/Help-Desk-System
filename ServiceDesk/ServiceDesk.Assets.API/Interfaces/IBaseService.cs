using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Interfaces
{
    public interface IBaseService<T, TDto> where T : Asset where TDto : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task AddAsync(TDto assetDto);
        Task UpdateAsync(TDto assetDto);
        Task DeleteAsync(Guid id);
        Task<List<TDto>> FilterAsync(Dictionary<string, object> searchParams);
    }
}
