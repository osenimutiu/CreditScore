using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ProductTypeAttribute))]
    public class ProductTypeAttributeListDto : FullAuditedEntityDto
    {
        public string ProductType { get; set; }
    }
}
