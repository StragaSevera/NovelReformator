using Microsoft.Extensions.DependencyInjection;

namespace NovelReformatorWebAPI.Services
{
    public class RequestServiceFactory : IRequestServiceFactory
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private IServiceScope _scope;

        public RequestServiceFactory(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void InitializeRequestServices()
        {
            _scope = _scopeFactory.CreateScope();
            _scope.ServiceProvider.GetService<LoggerService>();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}