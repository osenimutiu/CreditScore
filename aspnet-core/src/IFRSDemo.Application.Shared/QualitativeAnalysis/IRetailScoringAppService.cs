using Abp.Application.Services;
using IFRSDemo.QualitativeAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
    public interface IRetailScoringAppService : IApplicationService
    {
        RetailItemDto[] GetRetailItem();
        RetailScoringDto[] GetRetailScoring();
        List<string> GetDistictAttributeItems();
        RetailItemDto[] GetAttOption(string search);
        //HighEduLevelDto[] GetHighEduLevel(int id);
        //YearsSavingDto[] GetYearsSaving(int id);
        //DepPerMonthDto[] GetDepPerMonth(int id);
        //WithPerMonthDto[] GetWithPerMonth(int id);
        //ClientForMonthsDto[] GetClientForMonths(int id);
        //SubPerceptionDto[] GetSubPerception(int id);
        //CarOwnStatDto[] GetCarOwnStat(int id);
        //MaritalStatusDto[] GetMaritalStatus(int id);
        //EvdTrustWorthinessDto[] GetEvdTrustWorthiness(int id);
        //StrengthRefreeDto[] GetStrengthRefree(int id);
        //CollateralDto[] GetCollateral(int id);
        //NetChangeDto[] GetNetChange(int id);
        RetailCutoffDto[] GetRetailCutoff();
        Task PostRetailScoring(CreateRetailScoring input);
        Task PostRetailCutoff(CreateRetailCutOff input);
        void TruncateRetailCutOff();
        Task DeteteRetailScoring(int id);
    }
}
