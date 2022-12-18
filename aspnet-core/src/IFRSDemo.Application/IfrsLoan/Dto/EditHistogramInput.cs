using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class EditHistogramInput
    {
        public int Id { get; set; }
        public virtual string featurename { get; set; }
        public virtual string lowerBound { get; set; }
        public virtual double upperBound { get; set; }
        public virtual double count { get; set; }
        public virtual double percent { get; set; }
       // public virtual int? ComponentId { get; set; }
    }

    public class GetHistogramForEditOutput
    {
        public int Id { get; set; }
        public virtual string featurename { get; set; }
        public virtual string lowerBound { get; set; }
        public virtual double upperBound { get; set; }
        public virtual double count { get; set; }
        public virtual double percent { get; set; }
        //public virtual int? ComponentId { get; set; }
    }
    public class GetHistogramForEditInput
    {
        public int Id { get; set; }
    }
}
