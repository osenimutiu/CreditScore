using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public class Database : FullAuditedEntity
    {
        public virtual string DatabaseName { get; set; }
        public virtual string ServerName { get; set; }
        public virtual string ServiceServerName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string IntegratedSecurity { get; set; }
        public virtual string CompanyCode { get; set; }



    }
}
