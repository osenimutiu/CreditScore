using Abp.Application.Services;
using IFRSDemo.DigitalLending.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.DigitalLending
{
    public interface IIndividualAppService : IApplicationService
    {
        //IndividualAppDto[] GetIndApp();
        Task creatIndividualApp(CreateIndAppDto input);
        RiskAssessmentDto[] GetRiskAssessment();
        BankAccountDto[] GetBankAccounts();
        CreditLineConditionDto[] GetCreditLineConditions();
        RecommendationDto[] GetRecommendation();
    }
}
