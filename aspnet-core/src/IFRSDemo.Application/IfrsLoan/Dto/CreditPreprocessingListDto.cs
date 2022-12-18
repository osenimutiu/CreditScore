using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(CreditPreprocessing))]
    public class CreditPreprocessingListDto : FullAuditedEntityDto
    {
        
        public int PreId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int NumNull { get; set; }
        public double OutlIer { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Components { get; set; }
        public int Num { get; set; }
        [Column(TypeName = "nvarchar(850)")]
        public int Combination { get; set; }
    }
}
