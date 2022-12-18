using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IScoringInputDataRepository : IRepository<ScoringInputData, int>
    {
         void ComputeBulkScore();
    }
}
