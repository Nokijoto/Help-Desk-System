using Gateway.Clients;
using Gateway.Storage.Dtos;

namespace Gateway.Factories
{
    public class AssetClientFactory : IAssetClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AssetClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public AssetClient<TDto> CreateClient<TDto>(string endpoint) where TDto : class
        {
            var httpClient = _httpClientFactory.CreateClient();
            return new AssetClient<TDto>(httpClient, endpoint);
        }
    }

}
