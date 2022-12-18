using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.Curves.Dto
{
    public class KSTestCurveDto : EntityDto
    {
        public int? Score { get; set; }
        public int? Range { get; set; }
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public int? Cumm_Good { get; set; }
        public int? Cumm_Bad { get; set; }
        public double? Cumm_Perc_Good { get; set; }
        public double? Cumm_Perc_Bad { get; set; }
        public double? Cumm_Perc_Diff { get; set; }
        public int? Cumm_Pop_Good { get; set; }
        public int? Cumm_Pop_Bad { get; set; }
        public int? Volume_Accepted { get; set; }
        public double? Cumm_Accp_Perc { get; set; }
        public double? Cumm_Bad_Rate { get; set; }
    }

    public class GiniCurveDto : EntityDto
    {
        public bool Good_Bad { get; set; }
        public double? Score { get; set; }
        public double? Defaulters { get; set; }
        public int? CustomersTotal { get; set; }
        public double? Cumm_Perc_Defaulters { get; set; }
        public double? Cumm_Perc_Customers { get; set; }
        public double? AUC { get; set; }
    }

    public class ROCCurveDto : EntityDto
    {
        public double? CuttOff { get; set; }
        public double? true_positive { get; set; }
        public double? false_positive { get; set; }
        public double? Area { get; set; }
    }
	
	 public class TblWoe_AgeDto : EntityDto
    {
        public double WOE { get; set; }
        public string Age { get; set; }
    }
    public class TblWoe_TimeatJobDto : EntityDto   
    {
        public double WOE { get; set; }
        public string TimeatJob { get; set; }
    }
    public class TblWoe_PaymentPerformanceDto : EntityDto
    {
        public double WOE { get; set; }
        public string PaymentPerformance { get; set; }
    }
    public class Tbl_PsiDto : EntityDto
    {
        public string Score_Bands { get; set; }
        public double Actual { get; set; }
        public double Expected { get; set; }
        public double Actual_Expected { get; set; }
        public double Ln_Actual_Expected { get; set; }
        public double INDEX { get; set; }
        public double PSI { get; set; }
    }
    public class DescriptiveStatisticsDto : EntityDto
    {
        public string Variable { get; set; }
        public double NumberOfdate { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double StdDeviation { get; set; }
        public double RootMeansSquare { get; set; }
        public double StdErrormean { get; set; }
        public double Minimium { get; set; }
        public double Maximium { get; set; }
        public double Skewnes { get; set; }
        public double Kurtosis { get; set; }
    }

    public class TblOutput_TableDto : EntityDto
    {
        public string Unique_ID { get; set; }
        public bool TrainingSample { get; set; }
        public DateTime Date_opened { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
        public string Location { get; set; }
        public string Resident_status { get; set; }
        public double Time_at_Job { get; set; }
        public double Time_at_residence { get; set; }
        public string Product { get; set; }
        public string Current_Account_Status { get; set; }
        public decimal Total_assets { get; set; }
        public decimal Rent { get; set; }
        public double Rent_to_Income { get; set; }
        public double Return_on_Assets { get; set; }
        public double Time_at_Bank { get; set; }
        public int Number_of_products { get; set; }
        public string Payment_performance { get; set; }
        public int Previous_claims { get; set; }
        public bool Good_Bad { get; set; }
        public string Agebin { get; set; }
        public string Time_at_Jobbin { get; set; }
    }

    public class CreditScore_FeatureSelectionDto : EntityDto
    {
        public string Characteristic { get; set; }
        public double IV { get; set; }
        public string Inference { get; set; }
        public bool SelectStatus { get; set; }
    }
    public class Tbl_GoodBadInputDto : EntityDto
    {
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public string GoodLabel { get; set; }
        public string BadLabel { get; set; }
    }

    public class CreditScoreWOEDto : EntityDto
    {
        public string Characteristic { get; set; }
        public string Attribute { get; set; }
        public double WOE { get; set; }
    }

    public class Tbl_GoodBadInputRawDto : EntityDto
    {
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public string GoodLabel { get; set; }
        public string BadLabel { get; set; }
    }

    public class ViewbincountpercentageDto : EntityDto
    {
        public string attribute { get; set; }
        public string binning { get; set; }
        public double percentage { get; set; }
    }
}
