using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("CreditScore_LogisticRegEquation")]
   public class LogisticRegEquation : Entity<int>
    {
        public double Location { get; set; }
        public double Resident_Status { get; set; }
        public double Product { get; set; }
        public double Current_Account_Status { get; set; }
        public double Payment_Performance { get; set; }
        public double Age_bin { get; set; }
        public double Time_at_Job_bin { get; set; }
        public double Intercept { get; set; }
        public double Mean_Squared_Error { get; set; }
        public double Null_Deviance { get; set; }
        public double R_Square { get; set; }
        public double Residual_Defiance { get; set; }
        public double ROC_AUC { get; set; }
        public double P_Value { get; set; }
        public double Degree_of_Freedom { get; set; }
        public double DF_Predictors { get; set; }
        public double Degree_of_Freedomb { get; set; }
        public double Regression_Defiance { get; set; }
    }
}
