using Microsoft.Extensions.Logging;

namespace MyContacts.Services.ServiceImplementation
{
    public abstract class BaseService
    {
        protected readonly ILogger _logger;

        public BaseService(ILogger logger)
        {
            _logger = logger;
        }
    }
}