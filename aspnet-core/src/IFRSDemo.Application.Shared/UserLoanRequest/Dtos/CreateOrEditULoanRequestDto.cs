using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.UserLoanRequest.Dtos
{
    public class CreateOrEditULoanRequestDto : EntityDto<int?>
    {

        [StringLength(ULoanRequestConsts.MaxLoanTypeLength, MinimumLength = ULoanRequestConsts.MinLoanTypeLength)]
        public string LoanType { get; set; }

        [Range(ULoanRequestConsts.MinAmountValue, ULoanRequestConsts.MaxAmountValue)]
        public decimal Amount { get; set; }

        [Range(ULoanRequestConsts.MinTenorValue, ULoanRequestConsts.MaxTenorValue)]
        public int Tenor { get; set; }

        [StringLength(ULoanRequestConsts.MaxStatusLength, MinimumLength = ULoanRequestConsts.MinStatusLength)]
        public string Status { get; set; }

    }
}