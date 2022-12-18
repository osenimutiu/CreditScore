using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(HaveBankAccount))]
    public class HaveBankAccountListDto : EntityDto
    {
        public string Option { get; set; }
    }
    public class GetHaveBankAccountInput
    {
        public string Filter { get; set; }
    }
}
