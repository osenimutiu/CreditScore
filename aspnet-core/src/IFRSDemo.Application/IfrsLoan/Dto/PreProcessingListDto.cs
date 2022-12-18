using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(PreProcessing))]
    public class PreProcessingListDto : FullAuditedEntityDto
    {
        public string name { get; set; }
        public int num_null { get; set; }
        public double outl_ier { get; set; }
        public string components { get; set; }
        public int num { get; set; }
        public string combination { get; set; }

    }
}
