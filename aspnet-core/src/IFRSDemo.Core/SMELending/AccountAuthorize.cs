using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_AccountAuthorize")]
    public class AccountAuthorize : Entity<int>
    {
        public virtual string Option { get; set; }
    }
}
