using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(Bank))]
    public class BankListDto : EntityDto
    {
        public string BankNames { get; set; }
    }
}
