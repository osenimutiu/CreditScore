using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(LocationAttribute))]
    public class LocationAttributeListDto : FullAuditedEntityDto
    {
        public string LocationGroup { get; set; }
        public double NumberOfLoans { get; set; }
        public double NumberOfBadLoans { get; set; }
        public double NumberOfGoodLoans { get; set; }
        public double BadLoanPerc { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string BinGroup { get; set; }
        public double DB { get; set; }
        public double DG { get; set; }
        public double WOE { get; set; }
        public double DG_DB { get; set; }
        public double WoeDGBG { get; set; }
        public double ScoreAfterReg { get; set; }
        public double ScorePoint { get; set; }

    }
}
