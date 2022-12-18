using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
    [Table("Applicant_with_Accno")]
    public class ApplicantAttribute : FullAuditedEntity
    {
        [Column(TypeName = "nvarchar(500)")]
        public virtual string Applicant_With_Accno { get; set; }
     
    }
}
