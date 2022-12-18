
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(AppAttribute))]
    public class AppAttributeListDto : FullAuditedEntityDto
    {
        public string ApplicanType { get; set; }
    }
}
