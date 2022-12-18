using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public class DatabaseInfo : FullAuditedEntity
    {
        public Database Database { get; set; }

    }
}
