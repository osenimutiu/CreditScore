using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapTo(typeof(FinancialRatio))]
    public class CreateFinancialRatioInput
    {
        public int? TenantId { get; set; }
        public string RatioName { get; set; }
        public string RatioDefinition { get; set; }

    }

    [AutoMapFrom(typeof(FinancialRatio))]
    public class FinancialRatioListDto : FullAuditedEntityDto
    {
        public string RatioName { get; set; }
        public string RatioDefinition { get; set; }
    }

    public class GetFinancialRatioInput
    {
        public string Filter { get; set; }
        public string RatioNameFilter { get; set; }
    }

    public class GetFinancialRatioForEditOutput
    {
        public int Id { get; set; }
        public string RatioName { get; set; }
        public string RatioDefinition { get; set; }
    }
    public class GetFinancialRatioForEditInput
    {
        public int Id { get; set; }
    }
    public class EditFinancialRatioInput
    {
        public int Id { get; set; }
        public string RatioName { get; set; }
        public string RatioDefinition { get; set; }
    }
}
