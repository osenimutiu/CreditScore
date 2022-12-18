using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(InputDataValueCollector))]
    public class InputDataValueCollectorListDto : EntityDto
    {
        public string SelectedValues { get; set; }
        public int? TenantId { get; set; }
    }

    public class CollectAttributeDto : EntityDto
    {
        public string attributes { get; set; }
    }
}
