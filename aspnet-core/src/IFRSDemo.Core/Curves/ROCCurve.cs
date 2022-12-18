using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("CRTD_Roc_Data")]
    //CreditScore_ROC
    public class ROCCurve : Entity<int>
    {
        public double? CuttOff { get; set; }
        public double? true_positive { get; set; }
        public double? false_positive { get; set; }
        public double? Area { get; set; }
    }
}
