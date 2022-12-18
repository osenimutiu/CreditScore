using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_LoanElibility")]
    public class LoanElibility : FullAuditedEntity, IMayHaveTenant
    {
        public virtual int BusRegNigId { get; set; }
        public virtual double AnnualTurnOver { get; set; }
        public virtual int OperationId { get; set; }
        public virtual int HaveBankAccountId { get; set; }
        public virtual int HaveNINId { get; set; }
        public virtual int AccountAuthorizeId { get; set; }
        public int? TenantId { get; set; }
    }
}
