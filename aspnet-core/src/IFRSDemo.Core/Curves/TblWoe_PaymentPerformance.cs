using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("TblWoe_PaymentPerformance")]
   public class TblWoe_PaymentPerformance : Entity
    {
        public double WOE { get; set; }
        public string PaymentPerformance { get; set; }
    }
}

