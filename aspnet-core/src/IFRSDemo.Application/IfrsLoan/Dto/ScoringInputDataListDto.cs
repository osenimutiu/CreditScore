using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ScoringInputData))]
    public class ScoringInputDataListDto : FullAuditedEntityDto
    {
        public bool TrainingSample { get; set; }
        public string UniqueID { get; set; }
        public int Age { get; set; }
        public double Income { get; set; }
        public double ReturnonAssets { get; set; }
        public string Location { get; set; }
        public string Residentstatus { get; set; }
        public double TimeatJob { get; set; }
        public double Timeatresidence { get; set; }
        public string Product { get; set; }
        public string Sector { get; set; }
        public string Subsector { get; set; }
        public string CurrentAccountStatus { get; set; }
        public double Totalassets { get; set; }
        public double Rent { get; set; }
        public double RenttoIncome { get; set; }
        public double TimeatBank { get; set; }
        public  int Numberofproducts { get; set; }
        public  string Paymentperformance { get; set; }
        public  bool Previousclaims { get; set; }
        public  bool GoodBad { get; set; }
        public  string Dateopened { get; set; }

    }
}
