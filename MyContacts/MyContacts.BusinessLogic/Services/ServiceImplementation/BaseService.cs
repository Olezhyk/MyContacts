using Microsoft.Build.Framework;

namespace MyContacts.BusinessLogic.Services.ServiceImplementation
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