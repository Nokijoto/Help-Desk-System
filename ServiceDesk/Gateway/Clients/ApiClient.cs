using CrudBase;
using Gateway.Enums;
using Gateway.Storage.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Clients
{
    public class ApiClient<TDto> : IApiClient<TDto> where TDto : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public ApiClient(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint.TrimEnd('/') + "/";
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var result = await GetAsync<IEnumerable<TDto>>(_endpoint);
            return result?.ToList() ?? new List<TDto>();
        }


        public async Task<TDto> GetByIdAsync(Guid id)
        {
            return await GetAsync<TDto>($"{_endpoint}{id}");
        }

        public async Task AddAsync(TDto dto)
        {
            await PostAsync(_endpoint, dto);
        }

        public async Task AddNoteAsync(Guid id, TDto dto)
        {
            await PostAsync($"{_endpoint}{id}", dto);
        }

        public async Task AddTaskAsync(Guid id, TDto dto)
        {
            await PostAsync($"{_endpoint}{id}", dto);
        }

        public async Task AddElementAsync(Guid id, TDto dto)
        {
            await PostAsync($"{_endpoint}{id}/dodaj", dto);
        }

        public async Task UpdateAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}", dto);
        }

        public async Task UpdateAssigneeAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}/assignee", dto);
        }

        public async Task UpdateStatusAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}/status", dto);
        }

        public async Task UpdatePriorityAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}/priority", dto);
        }

        public async Task UpdateNoteAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}/updatenote", dto);
        }

        public async Task UpdateTaskAsync(Guid id, TDto dto)
        {
            await PutAsync($"{_endpoint}{id}/updatetask", dto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await DeleteAsync($"{_endpoint}{id}");
        }

        public async Task CreateAsync(TDto dto)
        {
            await PostAsync(_endpoint, dto);
        }

        private async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<CrudOperationResult<T>>(content);

            return apiResponse.Result;
        }

        // Generic GET method
        private async Task<TResult> GetAsyncTickets<TResult>(string requestUri) where TResult : class
        {
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }
        private async Task PostAsync<TData>(string requestUri, TData data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task PutAsync<TData>(string requestUri, TData data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteAsync(string requestUri)
        {
            var response = await _httpClient.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
        }
        public async Task<IEnumerable<TDto>> GetAllAsyncTicket()
        {
            var result = await GetAsyncTickets<IEnumerable<TDto>>(_endpoint);
            return result ?? new List<TDto>();
        }

        public async Task<TDto> GetByIdAsyncTicket(Guid id)
        {
            var result = await GetAsyncTickets<TDto>($"{_endpoint}{id}");
            return result;
        }

        public async Task<IEnumerable<AssetDto>> GetByIdElementAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}{id}");
response.EnsureSuccessStatusCode();

var content = await response.Content.ReadAsStringAsync();
return JsonConvert.DeserializeObject<List<AssetDto>>(content);
        }

        public async Task UpdateAsynccc(Guid id, TDto dto)
        {
            await PutAsynccc($"{_endpoint}/{id}/status", dto);
        }

        private async Task PutAsynccc<TData>(string requestUri, TData data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
