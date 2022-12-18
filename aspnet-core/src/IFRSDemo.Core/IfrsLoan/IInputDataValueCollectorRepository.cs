using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.IfrsLoan
{
   public interface IInputDataValueCollectorRepository : IRepository<InputDataValueCollector, int>
    {
        void CreateSelectedAttributes(string param1, int param2);
        void FillCreditExclusion();
    }
}
