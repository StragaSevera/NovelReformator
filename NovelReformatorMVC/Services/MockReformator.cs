using System.Diagnostics;
using System.Threading.Tasks;
using NovelReformatorClassLib;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services
{
    internal class MockReformator : IReformatorService
    {
        public Task<string> Reformat(ApiRequest apiRequest)
        {
            Debug.WriteLine($"Mocking reformatting service: type is {apiRequest.Type}, " +
                            $"content is {apiRequest.Content}");
            return Task.FromResult(apiRequest.Type + ": " + apiRequest.Content);
        }
    }
}