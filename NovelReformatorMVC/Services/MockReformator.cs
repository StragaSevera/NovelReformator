using System.Diagnostics;
using System.Threading.Tasks;
using NovelReformatorClassLib;

namespace NovelReformatorMVC.Services
{
    internal class MockReformator : IReformatorService
    {
        public Task<string> Reformat(string input, ReformatorType reformatorType)
        {
            Debug.WriteLine($"Mocking reformatting service: type is {reformatorType}, input is {input}");
            return Task.FromResult(reformatorType + ": " + input);
        }
    }
}