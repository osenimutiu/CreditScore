using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ApplicationScoring))]
    public class ApplicationScoringListDto : FullAuditedEntityDto
    {
    
    public int? ProductTypeId { get; set; }
    public string LoanRequest { get; set; }
    public double Amount { get; set; }
    public int TenorMonth { get; set; }
    public int? Appld { get; set; }
    public int? ApplicantId { get; set; }
    public int? AgeAttributeId { get; set; }
    public int? IncomeAttributeId { get; set; }
    public int? LocationAttributeId { get; set; }
    public int? RentAttributeId { get; set; }
    public int? RenttoIncomeAttributeId { get; set; }
    public int? ReturnonAssetsAttributeId { get; set; }
    public int? SubSectorAttributeId { get; set; }
    public string ExtraParam1 { get; set; }
    public int ExtraParam2 { get; set; }

    public string ApplicationScoringTypeAgeGroup { get; set; }
    public string ApplicationScoringTypeApp { get; set; }
    public string ApplicationScoringTypeApplicant { get; set; }
    public string ApplicationScoringTypeLocationGroup { get; set; }
    public string ApplicationScoringProductType { get; set; }
    public string ApplicationScoringTypeIncomeRange { get; set; }
    public string ApplicationScoringTypeRentGroup { get; set; }
    public string ApplicationScoringTypeRentToIncomeGroup { get; set; }
    public string ApplicationScoringTypeReturnonAssets { get; set; }
    public string ApplicationScoringTypeSectorGroup { get; set; }
    }
}
