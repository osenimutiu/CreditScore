using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class ApplicationScoringDto : EntityDto
    {
    //    [Column(TypeName = "nvarchar(500)")]
        public string Applicant { get; set; }

        public int? ProductTypeId { get; set; }



        //[Column(TypeName = "nvarchar(500)")]
        public string LoanRequest { get; set; }
        public double Amount { get; set; }
        public int TenorMonth { get; set; }
        public int? AgeAttributeId { get; set; }
        public int? IncomeAttributeId { get; set; }
        public int? LocationAttributeId { get; set; }
        public int? RentAttributeId { get; set; }
        public int? RenttoIncomeAttributeId { get; set; }
        public int? ReturnonAssetsAttributeId { get; set; }
        public int? SubSectorAttributeId { get; set; }
        public string ExtraParam1 { get; set; }
        public int ExtraParam2 { get; set; }
    }
}
