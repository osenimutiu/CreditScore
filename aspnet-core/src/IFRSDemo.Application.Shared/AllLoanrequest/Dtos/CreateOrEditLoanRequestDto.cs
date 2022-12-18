using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.AllLoanrequest.Dtos
{
    public class CreateOrEditLoanRequestDto : EntityDto<int?>
    {

        [Required]
        [StringLength(LoanRequestConsts.MaxCustomerLength, MinimumLength = LoanRequestConsts.MinCustomerLength)]
        public string Customer { get; set; }

        [Required]
        [StringLength(LoanRequestConsts.MaxLoanTypeLength, MinimumLength = LoanRequestConsts.MinLoanTypeLength)]
        public string LoanType { get; set; }

        public decimal Amount { get; set; }

        [Range(LoanRequestConsts.MinTenorValue, LoanRequestConsts.MaxTenorValue)]
        public int Tenor { get; set; }

        [StringLength(LoanRequestConsts.MaxStatuaLength, MinimumLength = LoanRequestConsts.MinStatuaLength)]
        public string Statua { get; set; }

    }
}