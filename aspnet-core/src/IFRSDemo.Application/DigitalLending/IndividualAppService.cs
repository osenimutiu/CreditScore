using Abp.Domain.Repositories;
using IFRSDemo.DigitalLending.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace IFRSDemo.DigitalLending
{
    public class IndividualAppService : IFRSDemoAppServiceBase, IIndividualAppService
    {
        private readonly IRepository<IndividualApp> _ind;
        private readonly IRepository<RiskAssessment> _risk;
        private readonly IRepository<BankAccount> _bankAcc;
        private readonly IRepository<CreditLineCondition> _cred;
        private readonly IRepository<LendingOutput> _lend;
        public IndividualAppService(IRepository<IndividualApp> ind, IRepository<RiskAssessment> risk, IRepository<BankAccount> bankAcc, IRepository<CreditLineCondition> cred,
                                    IRepository<LendingOutput> lend)
        {
            _ind = ind;
            _risk = risk;
            _bankAcc = bankAcc;
            _cred = cred;
            _lend = lend;
        }

        public async Task creatIndividualApp(CreateIndAppDto input)
        {
            var ind = ObjectMapper.Map<IndividualApp>(input);
            await _ind.InsertAsync(ind);
        }

        public BankAccountDto[] GetBankAccounts()
        {
            var list = from e in _bankAcc.GetAll()
                       select new BankAccountDto()
                       {
                           AvgMonInflow = e.AvgMonInflow,
                           InflowGrowthRate = e.InflowGrowthRate,
                           YearlyRepayments = e.YearlyRepayments,
                           CreditLineAmount = e.CreditLineAmount,
                           Id = e.Id
                       };
            return list.OrderByDescending(s => s.Id).Take(1).ToArray();
        }

        public CreditLineConditionDto[] GetCreditLineConditions()
        {
            var list = from e in _cred.GetAll()
                       select new CreditLineConditionDto()
                       {
                           LoanDuration = e.LoanDuration,
                           CommitmentPeriod = e.CommitmentPeriod,
                           RepaymentFrequency = e.RepaymentFrequency,
                           Scoring = e.Scoring,
                           CLAmount = e.CLAmount,
                           InterestRate = e.InterestRate,
                           Fee = e.Fee,
                           OverrideTerms = e.OverrideTerms,
                           Id = e.Id
                       };
            return list.OrderByDescending(s => s.Id).Take(1).ToArray();
        }

        //public IndividualAppDto[] GetIndApp()
        //{
        //    var list = from e in _ind.GetAll()
        //               select new IndividualAppDto()
        //               {
        //                   UniqueId = e.UniqueId,
        //                   SrcIncome = e.SrcIncome,
        //                   DOB = e.DOB,
        //                   Application = e.Application,
        //                   RequestAmount = e.RequestAmount,
        //                   AnnualInflow = e.AnnualInflow,
        //                   LoanPurpose = e.LoanPurpose,
        //                   ApplicationDate = e.ApplicationDate,
        //                   Duration = e.Duration,
        //                   Id = e.Id
        //               };
        //    return list.ToArray();
        //}

        public RiskAssessmentDto[] GetRiskAssessment()
        {
            var list = from e in _risk.GetAll()
                       select new RiskAssessmentDto()
                       {
                           RedWarnSignals = e.RedWarnSignals,
                           YellowWarnSignals = e.YellowWarnSignals,
                           QualitativeWarnSignals = e.QualitativeWarnSignals,
                           PerformanceModel = e.PerformanceModel,
                           Id = e.Id
                       };
            return list.OrderByDescending(s => s.Id).Take(1).ToArray();
        }
        public RecommendationDto[] GetRecommendation()
        {
            var list = from e in _lend.GetAll()
                       select new RecommendationDto()
                       {
                           Amount = e.Amount,
                           Score = e.Score,
                           Recommendation = e.Recommendation,
                           Rating = e.Rating,
                           Id = e.Id
                       };
            return list.OrderByDescending(s=>s.Id).Take(1).ToArray();
        }
    }
}
