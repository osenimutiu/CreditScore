using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.IfrsLoan
{
   public interface IScoringInputDataEngineManager
    {
        void CreateScoringInputData(List<ScoringInputData> input);
        void UpdateScoringInputDataAsync(ScoringInputData input);
        Task<List<ScoringInputData>> GetListScoringInputData();
    }
}
