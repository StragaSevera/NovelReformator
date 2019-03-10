using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using NovelReformatorClassLib;

namespace NovelReformatorMVC.Services
{
    internal class ApiReformator : IReformatorService
    {
        public async Task<string> Reformat(string input, ReformatorType reformatorType)
        {
            var url = $"https://localhost:5003/api/reformat/{reformatorType.ToString().ToLower()}";
            using (var httpClient = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = new StringContent(input);
                using (var response = await httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}