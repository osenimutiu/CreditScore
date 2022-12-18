using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DigitalLending.Dto
{
    public class IndividualAppDto : EntityDto
    {
        public string UniqueId { get; set; }
        public string SrcIncome { get; set; }
        public DateTime DOB { get; set; }
        public string Application { get; set; }
        public decimal RequestAmount { get; set; }
        public decimal AnnualInflow { get; set; }
        public string LoanPurpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int Duration { get; set; }
    }
    public class BankAccountDto : EntityDto
    {
        public decimal AvgMonInflow { get; set; }
        public int InflowGrowthRate { get; set; }
        public int YearlyRepayments { get; set; }
        public decimal CreditLineAmount { get; set; }
    }
    public class CreateIndAppDto
    {
        public string UniqueId { get; set; }
        public string SrcIncome { get; set; }
        public DateTime DOB { get; set; }
        public string Application { get; set; }
        public decimal RequestedAmount { get; set; }
        public string LoanPurpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int Duration { get; set; }
    }

    public class RiskAssessmentDto : EntityDto
    {
        public decimal RedWarnSignals { get; set; }
        public decimal YellowWarnSignals { get; set; }
        public decimal QualitativeWarnSignals { get; set; }
        public decimal PerformanceModel { get; set; }
    }
    public class CreditLineConditionDto : EntityDto
    {
        public int LoanDuration { get; set; }
        public int CommitmentPeriod { get; set; }
        public int RepaymentFrequency { get; set; }
        public int Scoring { get; set; }
        public decimal CLAmount { get; set; }
        public int InterestRate { get; set; }
        public decimal Fee { get; set; }
        public string OverrideTerms { get; set; }
    }
    public class RecommendationDto : EntityDto
    {
        public decimal Amount { get; set; }
        public int Score { get; set; }
        public string Recommendation { get; set; }
        public string Rating { get; set; }
    }
    public class GetDigSetUpForEditOutput
    {
        public int Id { get; set; }
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

    public class GetDigSetUpForEditInput
    {
        public int Id { get; set; }
    }
    public class EditDigSetUpInput
    {
        public int Id { get; set; }
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

    public class DigSetUpDto : EntityDto
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

    public class SeverityDto
    {
        public double param1 { get; set; }
        public double param2 { get; set; }
        public double param3 { get; set; }
        public double param4 { get; set; }
        public double param5 { get; set; }
        public double param6 { get; set; }
        public double param8 { get; set; }
        public double param9 { get; set; }
        public double param10 { get; set; }
        public double param11 { get; set; }
        public double param12 { get; set; }
        public double param13 { get; set; }
        public double param14 { get; set; }
        public double param15 { get; set; }
        public double param16 { get; set; }
        public double param17 { get; set; }
        public double param18 { get; set; }
        public double param19 { get; set; }
        public double param20 { get; set; }
        public double param21 { get; set; }
        public double param22 { get; set; }
        public double param23 { get; set; }
        public double param24 { get; set; }
        public double param25 { get; set; }
        public double param26 { get; set; }
        public double param27 { get; set; }
        public double param28 { get; set; }
        public double param29 { get; set; }
        public double param30 { get; set; }
        public double param31 { get; set; }
        public double param32 { get; set; }
        public double param33 { get; set; }
        public double param34 { get; set; }
        public double param35 { get; set; }
        public double param36 { get; set; }
        ////public double param37 { get; set; }
        public double param38 { get; set; }
        public double param39 { get; set; }
        public double param40 { get; set; }
        public double param41 { get; set; }
        public double param42 { get; set; }
    }
}
