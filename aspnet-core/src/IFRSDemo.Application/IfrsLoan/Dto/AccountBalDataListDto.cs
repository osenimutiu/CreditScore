using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(AccountBalData))]
    public class AccountBalDataListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Income { get; set; }
        public int? Rent_Range { get; set; }
        public int? Rent_Income { get; set; }
        public int? ROA { get; set; }
        public int? Sector { get; set; }
        public int? Location { get; set; }
        public int? DTSR { get; set; }
        public double? OutBal { get; set; }
        public double? coverage { get; set; }
        public double? bal_other_fi { get; set; }
    }
}
