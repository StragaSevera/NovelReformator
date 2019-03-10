using System.Threading.Tasks;
using NovelReformatorClassLib;

namespace NovelReformatorMVC.Services
{
    public interface IReformatorService
    {
        Task<string> Reformat(string input, ReformatorType reformatorType);
    }
}