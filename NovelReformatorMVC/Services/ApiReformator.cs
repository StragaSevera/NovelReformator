using System.Net.Http;
using System.Threading.Tasks;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services
{
    internal class ApiReformator : IReformatorService
    {
        public async Task<ApiResponse> Reformat(ApiRequest apiRequest)
        {
            const string url = "https://localhost:5003/api/reformat";
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.PostAsJsonAsync(url, apiRequest))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<ApiResponse>();
            }
        }
    }
}