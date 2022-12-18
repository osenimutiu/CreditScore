using Abp.Domain.Repositories;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IInputDataRepository : IRepository<InputData, int>
    {
        Task<List<string>> GetDropdown();
       
    }
}
