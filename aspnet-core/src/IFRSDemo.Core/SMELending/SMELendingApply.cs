using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_SMELendingApply")]
    public class SMELendingApply : FullAuditedEntity, IMayHaveTenant
    {
        public virtual int ApplicatioNo { get; set; }
        public virtual string BusinessName { get; set; }
        public int? TenantId { get; set; }
        public virtual int? LoanTypeId { get; set; }

        [ForeignKey("LoanTypeId")]
        public LoanType LoanTypeFK { get; set; }
       
        public virtual double LoanAmount { get; set; }
        public virtual int LoanTenor { get; set; }
        public virtual string Bvn { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual int TitleId { get; set; }
        public virtual string BusinessAccountNo { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string DateOfBirth { get; set; }
        public virtual int GenderId { get; set; }
        public virtual string Phone { get; set; }
        public virtual int BankId { get; set; }
        [ForeignKey("BankId")]
        public Bank BankFK { get; set; }
        public virtual string BankAccountNo { get; set; }

    }
}
