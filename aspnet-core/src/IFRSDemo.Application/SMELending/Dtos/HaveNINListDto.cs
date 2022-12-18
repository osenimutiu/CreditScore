using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(HaveNIN))]
    public class HaveNINListDto : EntityDto
    {
        public string Option { get; set; }
    }
    public class GetHaveNINInput
    {
        public string Filter { get; set; }
    }
}
