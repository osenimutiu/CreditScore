using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SetUp
{
    [Table("Tbl_Feature_Selection")]
    public class Method : Entity<int>
    {
        public string MethodName { get; set; }
    }
}
