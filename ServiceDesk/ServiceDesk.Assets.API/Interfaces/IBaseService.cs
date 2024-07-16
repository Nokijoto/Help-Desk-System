using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Interfaces
{
    public interface IBaseService<T, TDto> where T : Asset where TDto : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task AddAsync(TDto assetDto);
        Task UpdateAsync(Guid id,TDto assetDto);
        Task DeleteAsync(Guid id);
        //Task<List<TDto>> GetFilteredAssets<TDto>(AssetFilterDto filter);
    }
}
