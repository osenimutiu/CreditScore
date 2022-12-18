using Abp.Application.Services;
using IFRSDemo.QualitativeAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
   public interface ISCMonitoringAppService : IApplicationService
    {
        Task CreateSCMonitoring(CreateSCMonitoringDto input);
        BinRangeDto[] GetBinRange();
        Task DeleteSCMonitoring(int id);
    }
}
