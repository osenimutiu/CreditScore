using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    public class DigSetUp : Entity<int>
    {
        public double EventBadCollPayment { get; set; }
        public double FraudEvent { get; set; }
        public double FreqAdvPayments { get; set; }
        public double NotEnoughBankAccforScoring { get; set; }
        public double MajorNewLendingObligationsIdentified { get; set; }
        public double NotEnoughInflowsGrantCreditLine { get; set; }
        public double HighPredModelDefProb { get; set; }
        public double NotEnoughSpaceCreditLine { get; set; }
        public double AffordableCreditLineAmount { get; set; }
        public string InsufficientBankAccountBuffer { get; set; }
        public double InsufficientLevelInflowVersusStatedRev { get; set; }
        public double NotEnoughOverdraftBufferAvailable { get; set; }
        public double SignificantReductionBankAccInflows { get; set; }
        public double HighLeverage { get; set; }
        public double NegativeInsufficientDebtServiceCovRatio { get; set; }
        public double InsufficientProfitMargin { get; set; }
        public bool EmailAddIdentAutGen { get; set; }
        public bool EmailAddDisEmailServ { get; set; }
        public bool EmailAddBounces { get; set; }
        public bool NoMixRecordFoundDomainEmailAdd { get; set; }
        public bool ConnSMTP { get; set; }
        public double CompYearBusiness { get; set; }
        public double ShareCapital { get; set; }
        public double UnableVerifyUserPayAcc { get; set; }
        public double CourtActions { get; set; }
        public double CourtWrits { get; set; }
        public double CreditEnquries { get; set; }
        public double DefaultStatus { get; set; }
        public double ExternalAdmin { get; set; }
        public double PaymentDefaults { get; set; }
        public double PetOccurrence { get; set; }
        public double CurrDirectorships { get; set; }
        public double DirecAge { get; set; }
        public double Bankruptcy { get; set; }
        public double CommercialDefaults { get; set; }
        public double ConsumerDefaults { get; set; }
        public double CourtActionsForCreditBureau { get; set; }
        public double DisqDirectorship { get; set; }
        public double ProbFutureAdverseEvent { get; set; }
        public double ProbFutureSeriousEvent { get; set; }
        public double LowCreditBureauScore { get; set; }
        public double PreviouDirectorships { get; set; }
    }
}
