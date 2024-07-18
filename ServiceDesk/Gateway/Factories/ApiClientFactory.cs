using Gateway.Clients;
using Gateway.Storage.Dtos;
using System.Net.Http;

namespace Gateway.Factories
{
    public class ApiClientFactory : IApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public ApiClient<TDto> CreateClient<TDto>(string endpoint) where TDto : class
        {
            var httpClient = _httpClientFactory.CreateClient();
            return new ApiClient<TDto>(httpClient, endpoint);
        }
    }

}
