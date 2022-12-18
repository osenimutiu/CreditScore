using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(AllScore))]
    public class AllScoreListDto : FullAuditedEntityDto
    {
        [Column(TypeName = "nvarchar(255)")]
        public virtual string Group { get; set; }
        public virtual double Pd { get; set; }
        public virtual double Score { get; set; }
        public virtual int Item { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public virtual string ItemName { get; set; }
    }
}
