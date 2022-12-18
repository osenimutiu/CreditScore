using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IApplicationScoringRepository : IRepository<ApplicationScoring, int>
    {
         void ComputeApplicationScore(int param1, int param2, int param3, int param4, int param5, int param6, int param7, string param8, string param9, int param10);
         void ComputeApplicationScore2(string param11, string param9, string custid, int param10);
		 void GetTrain_TestParam(string param);
        void PostForAllRegression();
    }
}
