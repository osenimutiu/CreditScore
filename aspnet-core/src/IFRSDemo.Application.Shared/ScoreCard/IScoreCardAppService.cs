using Abp.Application.Services;
using IFRSDemo.ScoreCard.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.ScoreCard
{
    public interface IScoreCardAppService : IApplicationService
    {
        List<AgeDistributionDto> GetAgeDistribution();
        List<CharacteristicsAnalysisDto> GetCharacteristicsAnalyses(string attribute);
        List<CurrentAccDistDto> GetCurrentAccDist();
        List<ProfitAnalysisDto> GetProfitAnalysis();
        List<ScalingDto> GetScaling();
        List<ScoreCardReportDto> GetScoreCardReport();
        List<StabiltyTrendDto> GetStabiltyTrend();
        List<string> GetDistinctCharactBins();
        List<ScoreReportDto> GetScoreReport(string search); 
        List<ScoreCardScalingDto> GetScoreCardScaling();
        List<LogisticRegEquationDto> GetLogisticRegEquation();
        CreditScore_PointAllocationDto[] GetPointAllocation(string param);
        Task CreateCutOff(CreateTblCutOffDto cutOff);
        List<TblCutOffDto> GetTblCutOff();
        Tbl_AttributeCountDto[] GetAttributeCount();
        void CountAttributes(); 
        Task<GetScalingForEditOutput> GetScalingForEdit(GetScalingForEditInput input);
        Task EditScaling(EditScalingInput input);
        Task<GetTblScoreReportForEditOutput> GetTblScoreReportForEdit(GetTblScoreReportForEditInput input);
        List<GetTblScoreReportForEditOutput> GetTblScoreReport();
        List<string> GetDistinctAttributes();
        List<string> GetDistinctNames();
    }
}
