namespace NovelReformatorWebAPI.Services
{
    public interface IRequestServiceFactory
    {
        void InitializeRequestServices();

        void Dispose();
    }
}