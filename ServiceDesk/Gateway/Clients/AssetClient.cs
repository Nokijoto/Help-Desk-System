using CrudBase;
using Gateway.Enums;
using Gateway.Storage.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Clients
{
    public class AssetClient<TDto> where TDto : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public AssetClient(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint.TrimEnd('/') + "/";
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CrudOperationResult<List<TDto>>>(content);
            return result.Result;
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CrudOperationResult<TDto>>(content);
            return result.Result;
        }

        public async Task AddAsync(TDto dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Guid id, TDto dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_endpoint}{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}{id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<IEnumerable<TDto>> GetAllAsyncTicket()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<TDto>>(content);
            return result;
        }
    }
}
