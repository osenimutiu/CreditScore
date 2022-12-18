using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan.Dto;
using IFRSDemo.IfrsLoan;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IFRSDemo.IfrsLoan
{
   public interface IHistogramAppService : IApplicationService
    {
        ListResultDto<HistogramListDto> GetHistogram(GetHistogramInput input); 
        Task CreateHistogram(CreateHistogramInput input);
        Task DeleteHistogram(EntityDto input); 

        Task<GetHistogramForEditOutput> GetHistogramForEdit(GetHistogramForEditInput input);
        Task EditHistogram(EditHistogramInput input);
        Task<List<ComponentTableDto>> GetAllComponentForTableDropdown();

        string[] GetDistinctTop1Feature();
        string[] GetDistinctFeatures();
        string[] GetCombinations();
        void UpdateRecords(string optVal);
        void RunDistStat();
        //string GetAllHistogramChart(string ftname);
        //string GetHistogramData(string ftname);
    }
}
