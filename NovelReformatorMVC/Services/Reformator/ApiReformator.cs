using System.Net.Http;
using System.Threading.Tasks;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services.Reformator
{
    internal class ApiReformator : IReformatorService
    {
        private readonly string _baseUrl;

        public ApiReformator(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<ApiResponse> Reformat(ApiRequest apiRequest)
        {
            var url = _baseUrl;
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.PostAsJsonAsync(url, apiRequest))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<ApiResponse>();
            }
        }
    }
}