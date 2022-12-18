using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IFRSDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
   public class GetSMELendingApplyInput 
    {
        public string Filter { get; set; }
        public string BusinessNameFilter { get; set; }
    }
    [AutoMapFrom(typeof(SMELendingApply))]
    public class SMELendingApplyListDto : FullAuditedEntityDto
    {
        public int ApplicatioNo { get; set; }
        public string BusinessName { get; set; }
        public int? TenantId { get; set; }
        public int? LoanTypeId { get; set; }
        
        public double LoanAmount { get; set; }
        public int LoanTenor { get; set; }
        public string Bvn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TitleId { get; set; }
        public string BusinessAccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Phone { get; set; }
        public int BankId { get; set; }
        public string BankAccountNo { get; set; }
        public string LoanTypeDescription { get; set; }
        public string BankSelection { get; set; }

    }
    [AutoMapTo(typeof(SMELendingApply))]
    public class CreateSMELendingApplyInput
    {
        public int ApplicatioNo { get; set; }
        public string BusinessName { get; set; }
        public int? TenantId { get; set; }
        public int? LoanTypeId { get; set; }
       
        public double LoanAmount { get; set; }
        public int? LoanTenor { get; set; }
        public string Bvn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TitleId { get; set; }
        public string BusinessAccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Phone { get; set; }
        public int BankId { get; set; }
        public string BankAccountNo { get; set; }
    }
}
