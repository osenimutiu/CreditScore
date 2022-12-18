using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Score_CDF_Table")]
    public class ScoreCDFTable : FullAuditedEntity
    {
        public virtual double Score { get; set; }
        public virtual double CDF { get; set; }
        public virtual double CDF_Good { get; set; }
        public virtual double CDF_Bad { get; set; }
    }
}
