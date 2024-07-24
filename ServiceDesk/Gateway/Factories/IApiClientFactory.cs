using Gateway.Clients;
using Gateway.Storage.Dtos;

namespace Gateway.Factories
{
    public interface IApiClientFactory
    {
        ApiClient<TDto> CreateClient<TDto>(string endpoint) where TDto : class;
    }
}
