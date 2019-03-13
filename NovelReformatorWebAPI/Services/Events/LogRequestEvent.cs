using NovelReformatorClassLib.Models;
using Prism.Events;

namespace NovelReformatorWebAPI.Services.Events
{
    public class LogRequestEvent : PubSubEvent<ApiRequest>
    {
    }
}