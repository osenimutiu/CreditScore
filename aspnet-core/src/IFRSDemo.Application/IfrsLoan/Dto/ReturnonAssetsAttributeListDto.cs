using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ReturnonAssetsAttribute))]
    public class ReturnonAssetsAttributeListDto : FullAuditedEntityDto
    {
        public string ReturnonAssets { get; set; }
    }
}
