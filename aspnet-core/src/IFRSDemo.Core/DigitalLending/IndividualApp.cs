using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    [Table("Tbl_IndividualApplication")]
   public class IndividualApp : Entity<int>
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
    public class RiskAssessment : Entity<int>
    {
        public decimal RedWarnSignals { get; set; }
        public decimal YellowWarnSignals { get; set; }
        public decimal QualitativeWarnSignals { get; set; }
        public decimal PerformanceModel { get; set; }
    }

    public class BankAccount : Entity<int>
    {
        public decimal AvgMonInflow { get; set; }
        public int InflowGrowthRate { get; set; }
        public int YearlyRepayments { get; set; }
        public decimal CreditLineAmount { get; set; }
    }
    public class CreditLineCondition : Entity<int>
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

    public class LendingOutput : Entity<int>
    {
        public decimal Amount { get; set; }
        public int Score { get; set; }
        public string Recommendation { get; set; }
        public string Rating { get; set; }
    }
}
