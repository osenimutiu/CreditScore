using Abp.AutoMapper;
using System;
using IFRSDemo.IfrsLoan;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(ScoringInputData))]
    public class CreateScoringInputDataInput
    {
        public bool TrainingSample { get; set; }
        public string Unique_ID { get; set; }
        public int Age { get; set; }
        [Required]
        [MaxLength(ScoringInputData.MaxIncomeLength)]
        public double Income { get; set; }
        public double Return_on_Assets { get; set; }
        public string Location { get; set; }
        public string Resident_status { get; set; }
        public double Time_at_Job { get; set; }
        public double Time_at_residence { get; set; }
        public string Product { get; set; }
        public string Sector { get; set; }
        public string Sub_sector { get; set; }
        public string Current_Account_Status { get; set; }
        public double Total_assets { get; set; }
        public double Rent { get; set; }
        public double Rent_to_Income { get; set; }
        public double Time_at_Bank { get; set; }
        public int Number_of_products { get; set; }
        public string Payment_performance { get; set; }
        public bool Previous_claims { get; set; }
        public bool Good_Bad { get; set; }
        public DateTime Date_opened { get; set; }

    }
}
