using System.Threading.Tasks;
using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Services
{
    public interface IReformatorService
    {
        Task<ApiResponse> Reformat(ApiRequest apiRequest);
    }
}