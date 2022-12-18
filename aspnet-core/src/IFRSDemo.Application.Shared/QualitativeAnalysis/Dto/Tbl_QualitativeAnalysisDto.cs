using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis.Dto
{
    public class Tbl_QualitativeAnalysisDto : EntityDto
    {
        public string Attribute { get; set; }
        public int Weight { get; set; }
        public double Percentage { get; set; }
        public int MaxScore { get; set; }
        public string Value { get; set; }
        public int AttributeScore { get; set; }
        public int WeightedAttribute { get; set; }
    }
    public class AttributeItemDto : EntityDto
    {
        public string Attributes { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
    }
    public class tbl_scoreDto : EntityDto
    {
        public string CustomerName { get; set; }
        public int Score { get; set; }
    }
    public class Createtbl_scoreDto
    {
        public string CustomerName { get; set; }
        public int Score { get; set; }
    }

    public class PositionInIdustryDto : EntityDto
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class OwnershipDto : EntityDto
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class ProductContDto : EntityDto
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class LegalDto : EntityDto
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class Tbl_RatingDto : EntityDto
    {
        public string Rating { get; set; }
    }
    public class CreateRatingAttributeDto
    {
        public string Items { get; set; }
    }
//public class CriminalPenaltyDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class AccAccRecordDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class IntContRegulationDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class RoleAssignmentDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class NoAccountDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class RegEthicsDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class OtherUnthicalConductDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class EvdExpenditureDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class LevelOrgCorperationDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class RecordViolationDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class ManagementQualityDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class EvdCrtAccountingDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class LevelCmpIndustryDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
//public class AccShenaniggansDto : EntityDto
//{
//    public string Value { get; set; }
//    public int Score { get; set; }
//    public int ItemId { get; set; }
//}
    public class CutoffDto : EntityDto
    {
        public double CutoffValue { get; set; }
    }

    public class CreateQualitativeAnalysisDto
    {
        public string Attribute { get; set; }
        public int Weight { get; set; }
        public double Percentage { get; set; }
        public int MaxScore { get; set; }
        public string Value { get; set; }
        public int AttributeScore { get; set; }
        public int WeightedAttribute { get; set; }
    }

    public class CreateCutOffDto 
    {
        public double CutoffValue { get; set; }
    }
    public class RetailItemDto : EntityDto
    {
        public string Attributes { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }

    }

    public class RetailScoringDto : EntityDto
    {
        public string Attribute { get; set; }
        public int Weight { get; set; }
        public double Percentage { get; set; }
        public int MaxScore { get; set; }
        public string Value { get; set; }
        public int AttributeScore { get; set; }
        public int WeightedAttribute { get; set; }
    }
    //public class HighEduLevelDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class YearsSavingDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class DepPerMonthDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class WithPerMonthDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class ClientForMonthsDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class SubPerceptionDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class CarOwnStatDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class MaritalStatusDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class EvdTrustWorthinessDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class StrengthRefreeDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class CollateralDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    //public class NetChangeDto : EntityDto
    //{
    //    public string Value { get; set; }
    //    public int Score { get; set; }
    //    public int ItemId { get; set; }
    //}
    public class RetailCutoffDto : EntityDto
    {
        public double CutoffValue { get; set; } 
    }
    public class CreateRetailScoring
    {
        public string Attribute { get; set; }
        public int Weight { get; set; }
        public double Percentage { get; set; }
        public int MaxScore { get; set; }
        public string Value { get; set; }
        public int AttributeScore { get; set; }
        public int WeightedAttribute { get; set; }
    }
    public class CreateRetailCutOff
    {
        public double CutoffValue { get; set; }
    }

    public class CreateSCMonitoringDto
    {
        public int Scores { get; set; }
        public int Bin_name { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
    }
    public class SCMonitoringDto : EntityDto
    {
        public int Scores { get; set; }
        public string Bin_name { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
    }
    public class BinRangeDto : EntityDto
    {
        public string Range { get; set; }
    }

    //public class CreateRiskRatingDto
    //{
    //    public string Category { get; set; }
    //    public string Option { get; set; }
    //    public int Score { get; set; }
    //}
    public class RiskRatingDto : EntityDto
    {
        public string Category { get; set; }
        public string Option { get; set; }
        public int Score { get; set; }
    }


    public class RiskRatingItemDto : EntityDto
    {
        public int Position { get; set; }
        public string Category { get; set; }
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class GetQARatingForEditOutput
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public string RatingDescription { get; set; }
        public int Score { get; set; }
        public int Range { get; set; }
    }
    public class GetQARatingForEditInput
    {
        public int Id { get; set; }
    }
    public class EditQARatingInput
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public string RatingDescription { get; set; }
        public int Score { get; set; }
        public int Range { get; set; }
    }
    public class CreateQARatingDto
    {
        public string Rating { get; set; }
        public string RatingDescription { get; set; }
        public int Score { get; set; }
        public int Range { get; set; }
    }
    public class RatingAttributeDto : EntityDto
    {
        public string Items { get; set; }
    }
    public class QARatingDto : EntityDto
    {
        public string Rating { get; set; }
        public string RatingDescription { get; set; }
        public int Score { get; set; }
        public int Range { get; set; }
    }

    public class CreateProfit_AnalysisDto
    {
        public decimal? AverageLoan { get; set; }
        public decimal? Profit { get; set; }
        public int? Loss { get; set; }
        public int? TotalGood { get; set; }
        public int? TotalBad { get; set; }
    }
}
