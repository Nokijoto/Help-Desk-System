using CrudBase;

using ServiceDesk.Assets.CrossCutting.Dtos;

namespace ServiceDesk.Assets.API.Interfaces
{
    public interface IAssetsService
    {
        Task<CrudOperationResult<List<AssetDto>>> GetAll();

    }
}
