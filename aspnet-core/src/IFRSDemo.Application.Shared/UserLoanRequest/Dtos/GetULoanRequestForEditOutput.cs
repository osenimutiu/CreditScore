using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.UserLoanRequest.Dtos
{
    public class GetULoanRequestForEditOutput
    {
        public CreateOrEditULoanRequestDto ULoanRequest { get; set; }

    }
}