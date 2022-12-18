using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IFRSDemo.Curves.Dto;
using System.Threading.Tasks;
using IFRSDemo.Authorization;
using Abp.Authorization;

namespace IFRSDemo.Curves
{
    [AbpAuthorize(AppPermissions.Pages_Curve)]
    public class CurveAppService : IFRSDemoAppServiceBase, ICurveAppService
    {
        private readonly IRepository<KSTestCurve> _ktRepo;
        private readonly IRepository<GiniCurve> _giniRepo;
        private readonly IRepository<ROCCurve> _rocRepo;
		private readonly IRepository<TblWoe_Age> _ageRepo;
        private readonly IRepository<TblWoe_TimeatJob> _jobRepo;
        private readonly IRepository<TblWoe_PaymentPerformance> _performanceRepo;
        private readonly IRepository<Tbl_Psi> _psiRepo;
        private readonly IRepository<Output_Table> _outputRepo;
        private readonly IRepository<DescriptiveStatistics> _descRepo;
        private readonly IRepository<CreditScore_FeatureSelection> _featRepo;
        private readonly ICurveRepository _curveRepo;
        private readonly IRepository<Tbl_GoodBadInput> _goodbadRepo;
        private readonly IRepository<CreditScoreWOE> _creditScoreRepo; 
        private readonly IRepository<Tbl_GoodBadInputRaw> _inputRaweRepo;
        private readonly IRepository<Viewbincountpercentage> _viewPercentageRepo;
        public CurveAppService(IRepository<KSTestCurve> ktRepo, IRepository<GiniCurve> giniRepo, IRepository<ROCCurve> rocRepo,
                               IRepository<TblWoe_Age> ageRepo, IRepository<TblWoe_TimeatJob> jobRepo, 
                               IRepository<TblWoe_PaymentPerformance> performanceRepo, IRepository<Tbl_Psi> psiRepo,
                               IRepository<Output_Table> outputRepo, IRepository<DescriptiveStatistics> descRepo,
                               IRepository<CreditScore_FeatureSelection> featRepo, ICurveRepository curveRepo, IRepository<Tbl_GoodBadInput> goodbadRepo,
                               IRepository<CreditScoreWOE> creditScoreRepo, IRepository<Tbl_GoodBadInputRaw> inputRaweRepo, IRepository<Viewbincountpercentage> viewPercentageRepo)
        {
            _ktRepo = ktRepo;
            _giniRepo = giniRepo;
            _rocRepo = rocRepo;
			_ageRepo = ageRepo;
            _jobRepo = jobRepo;
            _performanceRepo = performanceRepo;
            _psiRepo = psiRepo;
            _outputRepo = outputRepo;
            _descRepo = descRepo;
            _featRepo = featRepo;
            _curveRepo = curveRepo;
            _goodbadRepo = goodbadRepo;
            _creditScoreRepo = creditScoreRepo;
            _inputRaweRepo = inputRaweRepo;
            _viewPercentageRepo = viewPercentageRepo;
        }

        public List<GiniCurveDto> GetGiniCurve()
        {
            var giniCurve = (from curve in _giniRepo.GetAll()
                             select new GiniCurveDto()
                             {
                                 Good_Bad = curve.Good_Bad,
                                 Score = curve.Score,
                                 Defaulters = curve.Defaulters,
                                 CustomersTotal = curve.CustomersTotal,
                                 Cumm_Perc_Defaulters = curve.Cumm_Perc_Defaulters,
                                 Cumm_Perc_Customers = curve.Cumm_Perc_Customers,
                                 AUC = curve.AUC,
                                 Id = curve.Id
                             }).ToList();
            return giniCurve;
        }

        public List<KSTestCurveDto> GetKSTest()
        {
            var ktTest = (from curve in _ktRepo.GetAll()
                             select new KSTestCurveDto()
                             {
                                 Score = curve.Score,
                                 Range = curve.Range,
                                 Good = curve.Good,
                                 Bad = curve.Bad,
                                 Cumm_Good = curve.Cumm_Good,
                                 Cumm_Bad = curve.Cumm_Bad,
                                 Cumm_Perc_Good = curve.Cumm_Perc_Good,
                                 Cumm_Perc_Bad = curve.Cumm_Perc_Bad,
                                 Cumm_Perc_Diff = curve.Cumm_Perc_Diff,
                                 Cumm_Pop_Good = curve.Cumm_Pop_Good,
                                 Cumm_Pop_Bad = curve.Cumm_Pop_Bad,
                                 Volume_Accepted = curve.Volume_Accepted,
                                 Cumm_Accp_Perc = curve.Cumm_Accp_Perc,
                                 Cumm_Bad_Rate = curve.Cumm_Bad_Rate,
                                 Id = curve.Id
                             }).ToList();
            return ktTest;
        }

        public List<ROCCurveDto> GetROC()
        {
            var rocCurve = (from curve in _rocRepo.GetAll() 
                             select new ROCCurveDto()
                             {
                                 CuttOff = curve.CuttOff,
                                 true_positive = curve.true_positive,
                                 false_positive = curve.false_positive,
                                 Area = curve.Area,
                                 Id = curve.Id
                             })/*.Where(y => y.Id < 38)*/.OrderByDescending(x => x.Id).ToList();
            return rocCurve;
        }
        public List<Tbl_PsiDto> GetPsi()
        {
            var result = from e in _psiRepo.GetAll()
                         select new Tbl_PsiDto()
                         {
                             PSI = e.PSI,
                             Score_Bands = e.Score_Bands,
                             Actual = e.Actual,
                             Expected = e.Expected,
                             Actual_Expected = e.Actual_Expected,
                             Ln_Actual_Expected = e.Ln_Actual_Expected,
                             INDEX = e.INDEX,
                             Id = e.Id
                         };
            return new List<Tbl_PsiDto>(ObjectMapper.Map<List<Tbl_PsiDto>>(result));
        }
		
		public List<TblWoe_TimeatJobDto> GetTimeatJob()
        {
            var result = from e in _jobRepo.GetAll()
                         select new TblWoe_TimeatJobDto()
                         {
                             WOE = e.WOE,
                             TimeatJob = e.TimeatJob,
                             Id = e.Id
                         };
            return new List<TblWoe_TimeatJobDto>(ObjectMapper.Map<List<TblWoe_TimeatJobDto>>(result));
        }

        public List<TblWoe_AgeDto> GetWoeAge()
        {
            var result = from e in _ageRepo.GetAll()
                         select new TblWoe_AgeDto()
                         {
                             WOE = e.WOE,
                             Age = e.Age,
                             Id = e.Id
                         };
            return new List<TblWoe_AgeDto>(ObjectMapper.Map<List<TblWoe_AgeDto>>(result));
        }

        public List<TblWoe_PaymentPerformanceDto> GetWoe_PaymentPerformance()
        {
            var result = from e in _performanceRepo.GetAll()
                         select new TblWoe_PaymentPerformanceDto()
                         {
                             WOE = e.WOE,
                             PaymentPerformance = e.PaymentPerformance,
                             Id = e.Id
                         };
            return new List<TblWoe_PaymentPerformanceDto>(ObjectMapper.Map<List<TblWoe_PaymentPerformanceDto>>(result));
        }

        public List<DescriptiveStatisticsDto> GetDescriptiveStatistics()
        {
            var result = from obj in _descRepo.GetAll()
                         select new DescriptiveStatisticsDto()
                         {
                             Variable = obj.Variable,
                             NumberOfdate = obj.NumberOfdate,
                             Mean = obj.Mean,
                             Median = obj.Median,
                             StdDeviation = obj.StdDeviation,
                             RootMeansSquare = obj.RootMeansSquare,
                             StdErrormean = obj.StdErrormean,
                             Minimium = obj.Minimium,
                             Maximium = obj.Maximium,
                             Skewnes = obj.Skewnes,
                             Kurtosis = obj.Kurtosis,
                             Id = obj.Id
                         };
            return result.ToList();


        }

        public List<TblOutput_TableDto> GetTblOutput()
        {
            var result = from obj in _outputRepo.GetAll()
                         select new TblOutput_TableDto()
                         {
                             Unique_ID = obj.Unique_ID,
                             TrainingSample = obj.TrainingSample,
                             Date_opened = obj.Date_opened,
                             Age = obj.Age,
                             Income = obj.Income,
                             Location = obj.Location,
                             Resident_status = obj.Resident_status,
                             Time_at_Job = obj.Time_at_Job,
                             Time_at_residence = obj.Time_at_residence,
                             Product = obj.Product,
                             Current_Account_Status = obj.Current_Account_Status,
                             Total_assets = obj.Total_assets,
                             Rent = obj.Rent,
                             Rent_to_Income = obj.Rent_to_Income,
                             Return_on_Assets = obj.Return_on_Assets,
                             Time_at_Bank = obj.Time_at_Bank,
                             Number_of_products = obj.Number_of_products,
                             Payment_performance = obj.Payment_performance,
                             Previous_claims = obj.Previous_claims,
                             Good_Bad = obj.Good_Bad,
                             Agebin = obj.Agebin,
                             Time_at_Jobbin = obj.Time_at_Jobbin,
                             Id = obj.Id
                         };
            return result.ToList();
        }

        public List<CreditScore_FeatureSelectionDto> GetCreditScore_FeatureSelection()
        {
            var result = from obj in _featRepo.GetAll()
                         select new CreditScore_FeatureSelectionDto()
                         {
                             Characteristic = obj.Characteristic,
                             IV = obj.IV,
                             Inference = obj.Inference,
                             SelectStatus = obj.SelectStatus,
                             Id = obj.Id
                         };
            return result.ToList();
        }

        public string[] GetDistictProduct()
        {
            var res = _curveRepo.GetDistictProduct();
            return res;
        }

        public void PostProductParam(string product)
        {
            _curveRepo.GetProductParam(product);
        }

        public string[] GetDistictCurrAccStatus()
        {
            var res = _curveRepo.GetDistictCurrAccStatus();
            return res;
        }

        public void PostCurrAccStatusParam(string currAccStat)
        {
            _curveRepo.GetCurrAccStatusParam(currAccStat);
        }

        public string[] GetDistictLocation()
        {
            var res = _curveRepo.GetDistictLocation();
            return res;
        }

        public void PostLocationParam(string location)
        {
            _curveRepo.GetLocationParam(location);
        }

        public string[] GetDistictResident_status()
        {
            var res = _curveRepo.GetDistictResident_status();
            return res;
        }

        public void PostResident_statusParam(string residentStatus)
        {
            _curveRepo.GetResident_statusParam(residentStatus);
        }

        public string[] GetDistictPayment_performance()
        {
            var res = _curveRepo.GetDistictPayment_performance();
            return res;
        }

        public void PostPayment_performanceParam(string payment_performance)
        {
            _curveRepo.GetPayment_performanceParam(payment_performance);
        }

        public string[] GetDistictAgebin()
        {
            var res = _curveRepo.GetDistictAgebin();
            return res;
        }

        public void PostAgebinParam(string agebin)
        {
            _curveRepo.GetAgebinParam(agebin);
        }

        public string[] GetDistictTime_at_Jobbin()
        {
            var res = _curveRepo.GetDistictTime_at_Jobbin();
            return res;
        }

        public void PostTime_at_JobbinParam(string time_at_Jobbin)
        {
            _curveRepo.GetTime_at_JobbinParam(time_at_Jobbin);
        }

        public void PostForAll()
        {
            _curveRepo.PostForAll();
        }

        public List<Tbl_GoodBadInputDto> GetTbl_GoodBadInputData()
        {
            var res = from e in _goodbadRepo.GetAll()
                      select new Tbl_GoodBadInputDto()
                      {
                          Good = e.Good,
                          Bad = e.Bad,
                          GoodLabel = e.GoodLabel,
                          BadLabel = e.BadLabel,
                          Id = e.Id
                      };
            return res.ToList();
        }

        public List<CreditScoreWOEDto> GetCreditScoreWOE(string xteristic)
        {
            var cre = (from curve in _creditScoreRepo.GetAll().Where(a=> a.Characteristic.ToLower() == xteristic.ToLower())
                             select new CreditScoreWOEDto()
                             {
                                 Characteristic = curve.Characteristic,
                                 Attribute = curve.Attribute,
                                 WOE = curve.WOE,
                                 Id = curve.Id
                             }).ToList();
            return cre;
        }

        public string[] GetDistinctXteristics()
        {
            var distinct = _creditScoreRepo.GetAll().Select(d => d.Characteristic).Distinct();
            return distinct.ToArray();
        }

        public List<Tbl_GoodBadInputRawDto> GetGoodBadInputRaw()
        {
            var cre = (from curve in _inputRaweRepo.GetAll()
                       select new Tbl_GoodBadInputRawDto()
                       {
                           Good = curve.Good,
                           Bad = curve.Bad,
                           GoodLabel = curve.GoodLabel,
                           BadLabel = curve.BadLabel,
                           Id = curve.Id
                       }).ToList();
            return cre;
        }

        public void PostProductParamRaw(string productRaw)
        {
            _curveRepo.PostProductParamRaw(productRaw);
        }

        public void PostForAllRaw()
        {
            _curveRepo.PostForAllRaw();
        }

        public void PostCurrAccStatParamRaw(string curraccstatRaw)
        {
            _curveRepo.PostCurrAccStatParamRaw(curraccstatRaw);
        }

        public void PostLocationParamRaw(string locationRaw)
        {
            _curveRepo.PostLocationParamRaw(locationRaw);
        }

        public void PostResidentStatusParamRaw(string residStatRaw)
        {
            _curveRepo.PostResidentStatusParamRaw(residStatRaw);
        }

        public void PostPayment_performanceParamRaw(string payment_performanceRaw)
        {
            _curveRepo.PostPayment_performanceParamRaw(payment_performanceRaw);
        }

        public void RunProcess()
        {
            _curveRepo.RunProcess();
        }

        public async Task<List<string>> GetHeaders()
        {
            return await _curveRepo.GetHeaders();
        }
        public void InsertHeaders()
        {
            _curveRepo.InsertHeaders();
        }

        public void ExecuteStabilityTrend(string param1, string param2, string param3)
        {
            _curveRepo.ExecuteStabilityTrend(param1,param2,param3);
        }

        public List<ViewbincountpercentageDto> GetViewbincountpercentage(string attrb)
        {
            var result = from obj in _viewPercentageRepo.GetAll().Where(t=>t.attribute.Contains(attrb))
                         select new ViewbincountpercentageDto()
                         {
                             attribute = obj.attribute,
                             binning = obj.binning,
                             percentage = obj.percentage,
                             Id = obj.Id
                         };
            return result.ToList();
        }

        public string[] GetDistinctAttributes()
        {
            var res = _viewPercentageRepo.GetAll().Select(d => d.attribute).Distinct();
            return res.ToArray();
        }
    }
}
