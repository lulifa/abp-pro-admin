using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Logging;

namespace RuiChen.AbpPro.Identity
{
    public class IdentityException : BusinessException, IExceptionWithSelfLogging
    {
        public IdentityException(
            string code = null,
            string message = null,
            string details = null,
            Exception innerException = null,
            LogLevel logLevel = LogLevel.Warning)
            : base(code, message, details, innerException, logLevel)
        {
        }

        public virtual void Log(ILogger logger)
        {
            logger.Log(
                LogLevel,
                "An id error occurred,code: {0}, Message: {1}, Details: {2}",
                Code,
                Message,
                Details);
        }
    }
}
