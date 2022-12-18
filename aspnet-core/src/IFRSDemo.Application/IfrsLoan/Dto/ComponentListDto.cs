using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IFRSDemo.IfrsLoan;

using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(Component))]
    public class ComponentListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
    }
}
