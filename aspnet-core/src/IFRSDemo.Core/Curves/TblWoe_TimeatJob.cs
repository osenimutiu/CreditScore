using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("TblWoe_TimeatJob")]
    public class TblWoe_TimeatJob : Entity
    {
        public double WOE { get; set; }
        public string TimeatJob { get; set; }
    }
}

