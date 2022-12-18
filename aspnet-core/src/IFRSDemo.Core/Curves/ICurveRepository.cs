using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.Curves
{
    public interface ICurveRepository : IRepository<DescriptiveStatistics, int>
    {
        string[] GetDistictProduct();
        void GetProductParam(string product);
        string[] GetDistictCurrAccStatus();
        void GetCurrAccStatusParam(string currAccStat);
        string[] GetDistictLocation();
        void GetLocationParam(string location);
        string[] GetDistictResident_status();
        void GetResident_statusParam(string residentStatus);
        string[] GetDistictPayment_performance();
        void GetPayment_performanceParam(string payment_performance);
        string[] GetDistictAgebin();
        void GetAgebinParam(string agebin);
        string[] GetDistictTime_at_Jobbin();
        void GetTime_at_JobbinParam(string time_at_Jobbin);
        void PostForAll();
        void PostProductParamRaw(string productRaw);
        void PostForAllRaw();
        void PostCurrAccStatParamRaw(string curraccstatRaw);
        void PostLocationParamRaw(string locationRaw);
        void PostResidentStatusParamRaw(string residStatRaw);
        void PostPayment_performanceParamRaw(string payment_performanceRaw);
        void RunProcess();
        Task<List<string>> GetHeaders();
        void InsertHeaders();
        void TruncateCutOff();
        void ExecuteStabilityTrend(string param1, string param2, string param3);
        void CountAttributes();

       bool InsertNewCoperateScore(string param1, string param2, string param3, double param4);

    }
}
