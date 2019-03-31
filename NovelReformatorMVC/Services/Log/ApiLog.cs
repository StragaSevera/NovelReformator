using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
    }
}