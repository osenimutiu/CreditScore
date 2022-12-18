using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ManualUpload
{
    [Table("Input_Data")]
    public class Tbl_ScoringData : Entity<int>
    {
        [Column(TypeName="varchar(100)")]
        public string Unique_ID { get; set; }
        public bool TrainingSample { get; set; }
        public DateTime Date_opened { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Location { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Resident_status { get; set; }
        public double Time_at_Job { get; set; }
        public double Time_at_residence { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Product { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Current_Account_Status { get; set; }
        public decimal Total_assets { get; set; }
        public decimal Rent { get; set; }
        public double Rent_to_Income { get; set; }
        public double Return_on_Assets { get; set; }
        public double Time_at_Bank { get; set; }
        public int Number_of_products { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Payment_performance { get; set; }
        public int Previous_claims { get; set; }
        public bool Good_Bad { get; set; }
        
    }
}
