using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IFRSDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(SMETitle))]
    public class SMETitleListDto : EntityDto
    {
        public string IndivividualTitle { get; set; }
    }
    public class GetSMETitleInput 
    {
        public string Filter { get; set; }
    }
}
