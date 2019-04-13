using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services.Log
{
    internal class ApiLog : ILogService
    {
        private readonly string _baseUrl;

        public ApiLog(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<IReadOnlyList<LogEntry>> GetAllAsync()
        {
            var url = _baseUrl;
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return (await response.Content.ReadAsAsync<List<LogEntry>>()).AsReadOnly();
            }
        }

        public async Task<LogEntry> GetByIDAsync(int id)
        {
            var url = _baseUrl + $"/{id}";
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<LogEntry>();
            }
        }

        public async Task<int> CreateAsync(LogEntry logEntry)
        {
            var url = _baseUrl;
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(logEntry), Encoding.Default, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                var responseID = await response.Content.ReadAsAsync<int>();
                return responseID;
            }
        }

        public async Task<bool> EditByIDAsync(int id, LogEntry logEntry)
        {
            var url = _baseUrl + $"/{id}";
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(logEntry), Encoding.Default, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                var responseID = await response.Content.ReadAsAsync<int>();
                return responseID == id;
            }
        }

        public async Task<bool> DeleteByIDAsync(int id)
        {
            var url = _baseUrl + $"/{id}";
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.DeleteAsync(url))
            {
                response.EnsureSuccessStatusCode();
                var responseID = await response.Content.ReadAsAsync<int>();
                return responseID == id;
            }
        }
    }
}