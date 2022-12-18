using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(BusRegNig))]
    public class BusRegNigListDto : EntityDto
    {
        public string Option { get; set; }
    }
    public class GetBusRegNigInput
    {
        public string Filter { get; set; }
    }
}
