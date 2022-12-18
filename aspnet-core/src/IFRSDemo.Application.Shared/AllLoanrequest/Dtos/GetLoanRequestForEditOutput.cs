using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.AllLoanrequest.Dtos
{
    public class GetLoanRequestForEditOutput
    {
        public CreateOrEditLoanRequestDto LoanRequest { get; set; }

    }
}