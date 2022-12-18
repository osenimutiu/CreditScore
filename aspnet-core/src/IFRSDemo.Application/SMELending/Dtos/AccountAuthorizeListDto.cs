using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(AccountAuthorize))]
    public class AccountAuthorizeListDto : EntityDto
    {
        public string Option { get; set; }
    }
    public class GetAccountAuthorizeInput
    {
        public string Filter { get; set; }
    }
}
