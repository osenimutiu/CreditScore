using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("CreditScore_DescriptiveStatistics")]
    public class DescriptiveStatistics : Entity
    {
        [Column(TypeName="varchar(250)")]
        public string Variable { get; set; }
        public double NumberOfdate { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double StdDeviation { get; set; }
        public double RootMeansSquare { get; set; }
        public double StdErrormean { get; set; }
        public double Minimium { get; set; }
        public double Maximium { get; set; }
        public double Skewnes { get; set; }
        public double Kurtosis { get; set; }
    }
}
