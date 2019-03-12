using NovelReformatorClassLib.Models;

namespace NovelReformatorMVC.Models.ViewModels
{
    public class RequestResponseComposite
    {
        public ApiRequest Request;
        public ApiResponse Response;

        public RequestResponseComposite()
        {
        }

        public RequestResponseComposite(ApiRequest request, ApiResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}