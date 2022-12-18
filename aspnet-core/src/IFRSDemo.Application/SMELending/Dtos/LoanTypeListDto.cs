using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(LoanType))]
    public class LoanTypeListDto : EntityDto
    {
        public string LoanTypes { get; set; }
    }
}
