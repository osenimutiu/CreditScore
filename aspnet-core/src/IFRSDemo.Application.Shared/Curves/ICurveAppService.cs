using Abp.Application.Services;
using IFRSDemo.Curves.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.Curves
{
    public interface ICurveAppService : IApplicationService
    {
        List<KSTestCurveDto> GetKSTest();
        List<GiniCurveDto> GetGiniCurve();
        List<ROCCurveDto> GetROC();
		 List<TblWoe_AgeDto> GetWoeAge();
        List<TblWoe_TimeatJobDto> GetTimeatJob();
        List<TblWoe_PaymentPerformanceDto> GetWoe_PaymentPerformance();
        List<Tbl_PsiDto> GetPsi();
        List<DescriptiveStatisticsDto> GetDescriptiveStatistics();
        List<TblOutput_TableDto> GetTblOutput();
        List<CreditScore_FeatureSelectionDto> GetCreditScore_FeatureSelection();
        string[] GetDistictProduct();
        void PostProductParam(string product);
        string[] GetDistictCurrAccStatus();
        void PostCurrAccStatusParam(string currAccStat);
        string[] GetDistictLocation();
        void PostLocationParam(string location);
        string[] GetDistictResident_status();
        void PostResident_statusParam(string residentStatus);
        string[] GetDistictPayment_performance();
        void PostPayment_performanceParam(string payment_performance);
        string[] GetDistictAgebin();
        void PostAgebinParam(string agebin);
        string[] GetDistictTime_at_Jobbin();
        void PostTime_at_JobbinParam(string time_at_Jobbin);
        void PostForAll();
        List<Tbl_GoodBadInputDto> GetTbl_GoodBadInputData(); 
        List<CreditScoreWOEDto> GetCreditScoreWOE(string xteristic);
        string[] GetDistinctXteristics(); 
        List<Tbl_GoodBadInputRawDto> GetGoodBadInputRaw();
        void PostProductParamRaw(string productRaw);
        void PostForAllRaw();
        void PostCurrAccStatParamRaw(string curraccstatRaw);
        void PostLocationParamRaw(string locationRaw);
        void PostResidentStatusParamRaw(string residStatRaw);
        void PostPayment_performanceParamRaw(string payment_performanceRaw);
        void RunProcess();
        Task<List<string>> GetHeaders();
        void InsertHeaders();
        void ExecuteStabilityTrend(string param1, string param2, string param3);
        List<ViewbincountpercentageDto> GetViewbincountpercentage(string attrb);

        string[] GetDistinctAttributes();
    }
}
