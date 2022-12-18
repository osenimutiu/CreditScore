using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.QualitativeAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
    public interface IQualitativeAnalysisAppService : IApplicationService
    {
        Tbl_QualitativeAnalysisDto[] GetQualitativeAnalysis();
        AttributeItemDto[] GetAttributeItem();
        List<string> GetDistictAttributeItems();
        AttributeItemDto[] GetAttOption(string search);
        void TruncateScoresForPost();
        List<tbl_scoreDto> GetSelectedScores();
        Task PostTotalScore(Createtbl_scoreDto obj);
        List<PositionInIdustryDto> GetPositionInIdustry();
        List<OwnershipDto> GetOwnership();
        List<ProductContDto> GetProductCont();
        List<LegalDto> GetLegal();
        void ObtainOption();
        Tbl_RatingDto[] GetRating();
        Task createRatingAttribute(CreateRatingAttributeDto input);
        void PreventDuplicateRating();
        CutoffDto[] GetCutoff();
        Task PostQualitativeAnalysis(CreateQualitativeAnalysisDto input);
        Task CreateCutOff(CreateCutOffDto input);
        void TruncateCutOff();
        Task Delete(EntityDto del);
        SCMonitoringDto[] GetSCMonitoring();
        BinRangeDto[] GetBinRange();
        Task CreateSCMonitoring(CreateSCMonitoringDto input);
        Task DeleteSCMonitoring(int id);
        QARatingDto[] GetQARating(); 
        Task<GetQARatingForEditOutput> GetQARatingEdit(GetQARatingForEditInput input);
        Task EditQARating(EditQARatingInput input);
        Task CreateQARating(CreateQARatingDto input);
        Task DeleteQARating(int id);
        RiskRatingItemDto[] GetRiskRatingItem(string cat);
        Task CreateProfitAnalysis(CreateProfit_AnalysisDto input);
        QARatingDto[] RateCooperateUser(int cooperatescore);
    }
}
