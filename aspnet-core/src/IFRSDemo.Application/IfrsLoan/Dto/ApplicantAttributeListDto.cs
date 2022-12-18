using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ApplicantAttribute))]
    public class ApplicantAttributeListDto : FullAuditedEntityDto
    {
        public string Applicant_With_Accno { get; set; }
    }
}
