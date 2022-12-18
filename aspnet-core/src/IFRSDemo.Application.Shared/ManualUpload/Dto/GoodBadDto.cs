using Abp.Application.Services.Dto;
using IFRSDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.ManualUpload.Dto
{
    public class GoodBadDto : EntityDto
    {
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public string GoodLabel { get; set; }
        public string BadLabel { get; set; }
    }
    public class Training_Test_ParaDto
    {
        public string i { get; set; }
    }
    public class Tbl_ScoringDataDto : EntityDto
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
    }

    public class GetInputDataInput : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
        public string UniqueIDFilter { get; set; }
    }

}
