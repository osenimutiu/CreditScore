using System.ComponentModel.DataAnnotations.Schema;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(ApplicationScoring))]
    public class CreateApplicationScoringInput
    {
        public int? TenantId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? Appld { get; set; }
        public int? ApplicantId { get; set; }
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
