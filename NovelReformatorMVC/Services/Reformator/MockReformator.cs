using System.Diagnostics;
using System.Threading.Tasks;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services.Reformator
{
    internal class MockReformator : IReformatorService
    {
        public Task<ApiResponse> Reformat(ApiRequest apiRequest)
        {
            Debug.WriteLine($"Mocking reformatting service: type is {apiRequest.Type}, " +
                            $"content is {apiRequest.Content}");
            return Task.FromResult(new ApiResponse
            {
                Content = apiRequest.Type + ": " + apiRequest.Content,
                Success = true
            });
        }
    }
}