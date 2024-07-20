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
    public class ApiClient<TDto> where TDto : class
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
            return await GetAsync<List<TDto>>(_endpoint);
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

        // Generic GET method
        private async Task<TResult> GetAsync<TResult>(string requestUri) where TResult : class
        {
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        // Generic POST method
        private async Task PostAsync<TData>(string requestUri, TData data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        // Generic PUT method
        private async Task PutAsync<TData>(string requestUri, TData data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        // Generic DELETE method
        private async Task DeleteAsync(string requestUri)
        {
            var response = await _httpClient.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
        }

        // Specific methods for Ticket
        public async Task<IEnumerable<TDto>> GetAllAsyncTicket()
        {
            return await GetAsync<IEnumerable<TDto>>(_endpoint);
        }

        public async Task<TDto> GetByIdAsyncTicket(Guid id)
        {
            return await GetAsync<TDto>($"{_endpoint}{id}");
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
