using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(GenderType))]
    public class GenderTypeListDto : EntityDto
    {
        public string Type { get; set; }
    }
}
