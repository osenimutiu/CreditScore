using Abp.Application.Services;
using IFRSDemo.Caliberation.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.Caliberation
{
    public interface IGiniInclusiveAppService : IApplicationService
    {
        List<GiniInclusiveDto> GetGiniInclusives();
        CalibrationCDto[] GetCalibrations();
        Task CreateSetUp(CreateSetUPDto input);
        SetuPPageDto[] GetSetUp();
        VintageAnalysisDto[] GetVintageAnalysis();
    }
}
