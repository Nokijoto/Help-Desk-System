using Gateway.Clients;
using Gateway.Storage.Dtos;

namespace Gateway.Factories
{
    public interface IAssetClientFactory
    {
        AssetClient<TDto> CreateClient<TDto>(string endpoint) where TDto : class;
    }
}
