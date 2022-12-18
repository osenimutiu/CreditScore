using Abp.Application.Services;
using IFRSDemo.Dto;
using IFRSDemo.Logging.Dto;

namespace IFRSDemo.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
