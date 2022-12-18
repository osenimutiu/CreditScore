using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.UserLoanRequest
{
    [Table("ULoanRequests")]
    public class ULoanRequest : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [StringLength(ULoanRequestConsts.MaxLoanTypeLength, MinimumLength = ULoanRequestConsts.MinLoanTypeLength)]
        public virtual string LoanType { get; set; }

        [Range(ULoanRequestConsts.MinAmountValue, ULoanRequestConsts.MaxAmountValue)]
        public virtual decimal Amount { get; set; }

        [Range(ULoanRequestConsts.MinTenorValue, ULoanRequestConsts.MaxTenorValue)]
        public virtual int Tenor { get; set; }

        [StringLength(ULoanRequestConsts.MaxStatusLength, MinimumLength = ULoanRequestConsts.MinStatusLength)]
        public virtual string Status { get; set; }

    }
}