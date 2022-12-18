using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.ScoreCard.Dto
{
    public class AgeDistributionDto : EntityDto
    {
        public string AgeBins { get; set; }
        public double Weight { get; set; }
        public double Score { get; set; }
    }
    
    public class CharacteristicsAnalysisDto : EntityDto
    {
        public string Attributes { get; set; }
        public string Bins { get; set; }
        public int DevFrequency { get; set; }
        public int RecFrequency { get; set; }
        public double DevFrequencyPerc { get; set; }
        public double RecFrequencyPerc { get; set; }
        public int SCPoints { get; set; }
        public double Index { get; set; }
    }
    public class CurrentAccDistDto : EntityDto
    {
        public string AgeBins { get; set; }
        public double Weight { get; set; }
        public double Score { get; set; }
    }
    public class ProfitAnalysisDto : EntityDto
    {
        public double CutOff { get; set; }
        public double TPCount { get; set; }
        public double FPCount { get; set; }
        public double Profit { get; set; }
        public double ModelDifference { get; set; }
    }

    public class ScalingDto : EntityDto
    {
        public string Items { get; set; }
        public double Values { get; set; }
    }
    public class ScoreCardReportDto : EntityDto
    {
        public string Characteristic { get; set; }
        public string CharacteristicBin { get; set; }
        public double ScoreCardPoints { get; set; }
    }
    public class StabiltyTrendDto : EntityDto
    {
        public string Bins { get; set; }
        public int SampleFrequency { get; set; }
        public int RecentFrequency { get; set; }
        public int ThreeMonthFrequency { get; set; }
        public int SixMonthFrequency { get; set; }
        public double SampleFrequencyPerc { get; set; }
        public double RecentFrequencyPerc { get; set; }
        public double ThreeMonthFrequencyPerc { get; set; }
        public double SixMonthFrequencyPerc { get; set; }
    }

    public class ScoreReportDto : EntityDto
    {
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string Value { get; set; }
        public double Score { get; set; }
    }

    public class ScoreCardScalingDto : EntityDto
    {
        public string ParameterGroup { get; set; }
        public string ParameterName { get; set; }
        public double Score_After_Regression { get; set; }
        public double Score_Card_Point { get; set; }
    }

    public class LogisticRegEquationDto : EntityDto
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

    public class CreditScore_PointAllocationDto : EntityDto
    {
        public string Attribute { get; set; }
        public string Binning { get; set; }
        public double WOE { get; set; }
        public double Score { get; set; }
    }

    public class CreateTblCutOffDto 
    {
        public double? CutOff { get; set; }
    }

    public class TblCutOffDto : EntityDto
    {
        public double? CutOff { get; set; }
    }
    public class Tbl_AttributeCountDto : EntityDto
    {
        public int AttributeCount { get; set; }
    }
    public class GetScalingForEditOutput
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public double Values { get; set; }
    }
    public class GetScalingForEditInput
    {
        public int Id { get; set; }
    }
    public class EditScalingInput
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public double Values { get; set; }
    }
    public class GetTblScoreReportForEditOutput
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public double? TotalScore { get; set; }
        public string QualitativeRating { get; set; }
    }
    public class GetTblScoreReportForEditInput
    {
        public int Id { get; set; }
    }
}
