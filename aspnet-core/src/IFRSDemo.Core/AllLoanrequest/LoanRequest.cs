using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.AllLoanrequest
{
    [Table("LoanRequests")]
    public class LoanRequest : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(LoanRequestConsts.MaxCustomerLength, MinimumLength = LoanRequestConsts.MinCustomerLength)]
        public virtual string Customer { get; set; }

        [Required]
        [StringLength(LoanRequestConsts.MaxLoanTypeLength, MinimumLength = LoanRequestConsts.MinLoanTypeLength)]
        public virtual string LoanType { get; set; }

        public virtual decimal Amount { get; set; }

        [Range(LoanRequestConsts.MinTenorValue, LoanRequestConsts.MaxTenorValue)]
        public virtual int Tenor { get; set; }

        [StringLength(LoanRequestConsts.MaxStatuaLength, MinimumLength = LoanRequestConsts.MinStatuaLength)]
        public virtual string Statua { get; set; }

    }
}