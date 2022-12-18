using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("TblWoe_Age")]
    public class TblWoe_Age : Entity
    {
        public double WOE { get; set; }
        public string Age { get; set; }
    }
}
