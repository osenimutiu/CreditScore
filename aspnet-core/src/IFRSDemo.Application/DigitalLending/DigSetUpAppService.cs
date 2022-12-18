using Abp.Domain.Repositories;
using IFRSDemo.DigitalLending.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace IFRSDemo.DigitalLending
{
    public class DigSetUpAppService : IFRSDemoAppServiceBase, IDigSetUpAppService
    {
        private readonly IRepository<DigSetUp> _repo;
        public DigSetUpAppService(IRepository<DigSetUp> repo)
        {
            _repo = repo;
        }

        public async Task EditDigSetUp(EditDigSetUpInput input)
        {
            var digSetUp = await _repo.GetAsync(input.Id);
            digSetUp.EventBadCollPayment = input.EventBadCollPayment;
            digSetUp.FraudEvent = input.FraudEvent;
            digSetUp.FreqAdvPayments = input.FreqAdvPayments;
            digSetUp.NotEnoughBankAccforScoring = input.NotEnoughBankAccforScoring;
            digSetUp.MajorNewLendingObligationsIdentified = input.MajorNewLendingObligationsIdentified;
            digSetUp.NotEnoughInflowsGrantCreditLine = input.NotEnoughInflowsGrantCreditLine;
            digSetUp.HighPredModelDefProb = input.HighPredModelDefProb;
            digSetUp.NotEnoughSpaceCreditLine = input.NotEnoughSpaceCreditLine;
            digSetUp.AffordableCreditLineAmount = input.AffordableCreditLineAmount;
            digSetUp.InsufficientBankAccountBuffer = input.InsufficientBankAccountBuffer;
             digSetUp.InsufficientLevelInflowVersusStatedRev = input.InsufficientLevelInflowVersusStatedRev;
            digSetUp.NotEnoughOverdraftBufferAvailable = input.NotEnoughOverdraftBufferAvailable;
            digSetUp.SignificantReductionBankAccInflows = input.SignificantReductionBankAccInflows;
             digSetUp.HighLeverage = input.HighLeverage;
            digSetUp.NegativeInsufficientDebtServiceCovRatio = input.NegativeInsufficientDebtServiceCovRatio;
            digSetUp.InsufficientProfitMargin = input.InsufficientProfitMargin;
             digSetUp.EmailAddIdentAutGen = input.EmailAddIdentAutGen;
            digSetUp.EmailAddDisEmailServ = input.EmailAddDisEmailServ;
            digSetUp.EmailAddBounces = input.EmailAddBounces;
             digSetUp.NoMixRecordFoundDomainEmailAdd = input.NoMixRecordFoundDomainEmailAdd;
            digSetUp.ConnSMTP = input.ConnSMTP;
            digSetUp.CompYearBusiness = input.CompYearBusiness;
             digSetUp.ShareCapital = input.ShareCapital;
            digSetUp.UnableVerifyUserPayAcc = input.UnableVerifyUserPayAcc;
            digSetUp.CourtActions = input.CourtActions;
             digSetUp.CourtWrits = input.CourtWrits;
            digSetUp.CreditEnquries = input.CreditEnquries;
            digSetUp.DefaultStatus = input.DefaultStatus;
            digSetUp.ExternalAdmin = input.ExternalAdmin;
            digSetUp.PaymentDefaults = input.PaymentDefaults;
             digSetUp.PetOccurrence = input.PetOccurrence;
             digSetUp.CurrDirectorships = input.CurrDirectorships;
             digSetUp.DirecAge = input.DirecAge;
             digSetUp.Bankruptcy = input.Bankruptcy;
             digSetUp.CommercialDefaults = input.CommercialDefaults;
             digSetUp.ConsumerDefaults = input.ConsumerDefaults;
             digSetUp.CourtActionsForCreditBureau = input.CourtActionsForCreditBureau;
             digSetUp.DisqDirectorship = input.DisqDirectorship;
             digSetUp.ProbFutureAdverseEvent = input.ProbFutureAdverseEvent;
             digSetUp.ProbFutureSeriousEvent = input.ProbFutureSeriousEvent;
             digSetUp.LowCreditBureauScore = input.LowCreditBureauScore;
             digSetUp.PreviouDirectorships = input.PreviouDirectorships;
            await _repo.UpdateAsync(digSetUp);
        }

        public DigSetUpDto[] GetDigLendSetUp()
        {
            var result = (from input in _repo.GetAll()
                          select new DigSetUpDto()
                          {
                              EventBadCollPayment = input.EventBadCollPayment,
                              FraudEvent = input.FraudEvent,
                              FreqAdvPayments = input.FreqAdvPayments,
                              NotEnoughBankAccforScoring = input.NotEnoughBankAccforScoring,
                              MajorNewLendingObligationsIdentified = input.MajorNewLendingObligationsIdentified,
                              NotEnoughInflowsGrantCreditLine = input.NotEnoughInflowsGrantCreditLine,
                              HighPredModelDefProb = input.HighPredModelDefProb,
                              NotEnoughSpaceCreditLine = input.NotEnoughSpaceCreditLine,
                              AffordableCreditLineAmount = input.AffordableCreditLineAmount,
                              InsufficientBankAccountBuffer = input.InsufficientBankAccountBuffer,
                              InsufficientLevelInflowVersusStatedRev = input.InsufficientLevelInflowVersusStatedRev,
                              NotEnoughOverdraftBufferAvailable = input.NotEnoughOverdraftBufferAvailable,
                              SignificantReductionBankAccInflows = input.SignificantReductionBankAccInflows,
                              HighLeverage = input.HighLeverage,
                              NegativeInsufficientDebtServiceCovRatio = input.NegativeInsufficientDebtServiceCovRatio,
                              InsufficientProfitMargin = input.InsufficientProfitMargin,
                              EmailAddIdentAutGen = input.EmailAddIdentAutGen,
                              EmailAddDisEmailServ = input.EmailAddDisEmailServ,
                              EmailAddBounces = input.EmailAddBounces,
                              NoMixRecordFoundDomainEmailAdd = input.NoMixRecordFoundDomainEmailAdd,
                              ConnSMTP = input.ConnSMTP,
                              CompYearBusiness = input.CompYearBusiness,
                              ShareCapital = input.ShareCapital,
                              UnableVerifyUserPayAcc = input.UnableVerifyUserPayAcc,
                              CourtActions = input.CourtActions,
                              CourtWrits = input.CourtWrits,
                              CreditEnquries = input.CreditEnquries,
                              DefaultStatus = input.DefaultStatus,
                              ExternalAdmin = input.ExternalAdmin,
                              PaymentDefaults = input.PaymentDefaults,
                              PetOccurrence = input.PetOccurrence,
                              CurrDirectorships = input.CurrDirectorships,
                              DirecAge = input.DirecAge,
                              Bankruptcy = input.Bankruptcy,
                              CommercialDefaults = input.CommercialDefaults,
                              ConsumerDefaults = input.ConsumerDefaults,
                              CourtActionsForCreditBureau = input.CourtActionsForCreditBureau,
                              DisqDirectorship = input.DisqDirectorship,
                              ProbFutureAdverseEvent = input.ProbFutureAdverseEvent,
                              ProbFutureSeriousEvent = input.ProbFutureSeriousEvent,
                              LowCreditBureauScore = input.LowCreditBureauScore,
                              PreviouDirectorships = input.PreviouDirectorships,
                              Id = input.Id
                          }).ToArray();
            return result;
        }

        public async Task<GetDigSetUpForEditOutput> GetDigSetUpEdit(GetDigSetUpForEditInput input)
        {
            var digSetUp = await _repo.GetAsync(input.Id);
            return ObjectMapper.Map<GetDigSetUpForEditOutput>(digSetUp);
        }

        public DigSetUpDto[] GetDigLendSetUpForExport()
        {
            var result = (from input in _repo.GetAll()
                          select new DigSetUpDto()
                          {
                              EventBadCollPayment = input.EventBadCollPayment,
                              FraudEvent = input.FraudEvent,
                              FreqAdvPayments = input.FreqAdvPayments,
                              NotEnoughBankAccforScoring = input.NotEnoughBankAccforScoring,
                              MajorNewLendingObligationsIdentified = input.MajorNewLendingObligationsIdentified,
                              NotEnoughInflowsGrantCreditLine = input.NotEnoughInflowsGrantCreditLine,
                              HighPredModelDefProb = input.HighPredModelDefProb,
                              NotEnoughSpaceCreditLine = input.NotEnoughSpaceCreditLine,
                              AffordableCreditLineAmount = input.AffordableCreditLineAmount,
                              InsufficientBankAccountBuffer = input.InsufficientBankAccountBuffer,
                              InsufficientLevelInflowVersusStatedRev = input.InsufficientLevelInflowVersusStatedRev,
                              NotEnoughOverdraftBufferAvailable = input.NotEnoughOverdraftBufferAvailable,
                              SignificantReductionBankAccInflows = input.SignificantReductionBankAccInflows,
                              HighLeverage = input.HighLeverage,
                              NegativeInsufficientDebtServiceCovRatio = input.NegativeInsufficientDebtServiceCovRatio,
                              InsufficientProfitMargin = input.InsufficientProfitMargin,
                              EmailAddIdentAutGen = input.EmailAddIdentAutGen,
                              EmailAddDisEmailServ = input.EmailAddDisEmailServ,
                              EmailAddBounces = input.EmailAddBounces,
                              NoMixRecordFoundDomainEmailAdd = input.NoMixRecordFoundDomainEmailAdd,
                              ConnSMTP = input.ConnSMTP,
                              CompYearBusiness = input.CompYearBusiness,
                              ShareCapital = input.ShareCapital,
                              UnableVerifyUserPayAcc = input.UnableVerifyUserPayAcc,
                              CourtActions = input.CourtActions,
                              CourtWrits = input.CourtWrits,
                              CreditEnquries = input.CreditEnquries,
                              DefaultStatus = input.DefaultStatus,
                              ExternalAdmin = input.ExternalAdmin,
                              PaymentDefaults = input.PaymentDefaults,
                              PetOccurrence = input.PetOccurrence,
                              CurrDirectorships = input.CurrDirectorships,
                              DirecAge = input.DirecAge,
                              Bankruptcy = input.Bankruptcy,
                              CommercialDefaults = input.CommercialDefaults,
                              ConsumerDefaults = input.ConsumerDefaults,
                              CourtActionsForCreditBureau = input.CourtActionsForCreditBureau,
                              DisqDirectorship = input.DisqDirectorship,
                              ProbFutureAdverseEvent = input.ProbFutureAdverseEvent,
                              ProbFutureSeriousEvent = input.ProbFutureSeriousEvent,
                              LowCreditBureauScore = input.LowCreditBureauScore,
                              PreviouDirectorships = input.PreviouDirectorships
                          }).ToArray();
            return result;
        }
    }
}
