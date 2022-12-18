using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SetUp
{
    [Table("Tbl_AgeRange")]
    public class AgeRange : Entity
    {
        public string Age { get; set; }
    }
}
