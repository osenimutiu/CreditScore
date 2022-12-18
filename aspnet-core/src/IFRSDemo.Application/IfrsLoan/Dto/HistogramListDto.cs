using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IFRSDemo.IfrsLoan;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(Histogram))]
    public class HistogramListDto : FullAuditedEntityDto
    {
        public virtual string featurename { get; set; }
        public virtual string lowerBound { get; set; }
        public virtual double upperBound { get; set; }
        public virtual double count { get; set; }
        public virtual double percent { get; set; }
        public virtual int? ComponentId { get; set; }
        //[ForeignKey("ComponentId")]
        //public Component ComponentIdFk { get; set; }
    }
}
