using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(Histogram))]
    public class CreateHistogramInput
    {
        
        [MaxLength(Histogram.MaxfeaturenameLength)]
        public virtual string featurename { get; set; }
        [MaxLength(Histogram.MaxlowerBoundLength)]
        public virtual string lowerBound { get; set; }
        [MaxLength(Histogram.MaxupperBoundLength)]
        public virtual double upperBound { get; set; }
        public virtual double count { get; set; }
        public virtual double percent { get; set; }
        public int? TenantId { get; set; }
        public virtual int? ComponentId { get; set; }

    }
}
