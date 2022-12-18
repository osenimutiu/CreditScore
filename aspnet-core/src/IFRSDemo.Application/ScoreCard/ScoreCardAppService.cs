using Abp.Domain.Repositories;
using IFRSDemo.ScoreCard.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IFRSDemo.Curves;
using System.Threading.Tasks;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.ScoreCard
{
    [AbpAuthorize(AppPermissions.Pages_ScoreCard)]
    public class ScoreCardAppService : IFRSDemoAppServiceBase, IScoreCardAppService
    {
        private readonly IRepository<AgeDistribution> _age;
        private readonly IRepository<CharacteristicsAnalysis> _characteristics;
        private readonly IRepository<CurrentAccDist> _curr;
        private readonly IRepository<ProfitAnalysis> _profit;
        private readonly IRepository<Scaling> _scaling; 
        private readonly IRepository<ScoreCardReport> _scorecard;
        private readonly IRepository<StabiltyTrend> _stabilityTrend;
        private readonly IRepository<ScoreReport> _report;
        private readonly IRepository<ScoreCardScaling> _scoreCardScalingReport;
        private readonly IRepository<LogisticRegEquation> _regEquat;
        private readonly IRepository<CreditScore_PointAllocation> _pointAllocation;
        private readonly IRepository<TblCutOff> _cutOff;
        private readonly ICurveRepository _curve;
        private readonly IRepository<Tbl_AttributeCount> _countRepo;
        private readonly IRepository<TblScoreReport> _scoreReport;
        public ScoreCardAppService(IRepository<AgeDistribution> age, IRepository<CharacteristicsAnalysis> characteristics, IRepository<CurrentAccDist> curr,
                                   IRepository<ProfitAnalysis> profit, IRepository<Scaling> scaling, IRepository<ScoreCardReport> scorecard, IRepository<StabiltyTrend> stabilityTrend,
                                   IRepository<ScoreReport> report, IRepository<ScoreCardScaling> scoreCardScalingReport, IRepository<LogisticRegEquation> regEquat, IRepository<CreditScore_PointAllocation> pointAllocation,
                                   IRepository<TblCutOff> cutOff, ICurveRepository curve, IRepository<Tbl_AttributeCount> countRepo, IRepository<TblScoreReport> scoreReport)
        {
            _age = age;
            _characteristics = characteristics;
            _curr = curr;
            _profit = profit;
            _scaling = scaling;
            _scorecard = scorecard;
            _stabilityTrend = stabilityTrend;
            _report = report;
            _scoreCardScalingReport = scoreCardScalingReport;
            _regEquat = regEquat;
            _pointAllocation = pointAllocation;
            _curve = curve;
            _cutOff = cutOff;
            _countRepo = countRepo;
            _scoreReport = scoreReport;
        }
        public Tbl_AttributeCountDto[] GetAttributeCount()
        {
            var result = (from e in _countRepo.GetAll()
                          select new Tbl_AttributeCountDto()
                          {
                              AttributeCount = e.AttributeCount,
                              Id = e.Id
                          }).ToArray();
            return result;
        }
        [AbpAuthorize(AppPermissions.Pages_CreateScoreCardCutOff)]
        public async Task CreateCutOff(CreateTblCutOffDto cutOff)
        {
            _curve.TruncateCutOff();
            var result = ObjectMapper.Map<TblCutOff>(cutOff);
            await _cutOff.InsertAsync(result);
        }
        public void CountAttributes()
        {
            _curve.CountAttributes();
        }
        public List<AgeDistributionDto> GetAgeDistribution()
        {
            var result = (from e in _age.GetAll()
                          select new AgeDistributionDto()
                          {
                              AgeBins = e.AgeBins,
                              Weight = e.Weight,
                              Score = e.Score,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<CharacteristicsAnalysisDto> GetCharacteristicsAnalyses(string attribute)
        {
            var result = (from e in _characteristics.GetAll().Where(v=>v.Attributes.ToLower() == attribute.ToLower())
                          select new CharacteristicsAnalysisDto()
                          {
                              Attributes = e.Attributes,
                              Bins = e.Bins,
                              DevFrequency = e.DevFrequency,
                              RecFrequency = e.RecFrequency,
                              DevFrequencyPerc = e.DevFrequency,
                              RecFrequencyPerc = e.RecFrequencyPerc,
                              SCPoints = e.SCPoints,
                              Index = e.Index,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<string> GetDistinctAttributes()
        {
            var dist = _characteristics.GetAll().Select(d => d.Attributes).Distinct();
            return dist.ToList();
        }

        public List<CurrentAccDistDto> GetCurrentAccDist()
        {
            var result = (from e in _curr.GetAll()
                          select new CurrentAccDistDto()
                          {
                              AgeBins = e.AgeBins,
                              Weight = e.Weight,
                              Score = e.Score,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<string> GetDistinctCharactBins()
        {
            var result = _scorecard.GetAll().Select(x => x.CharacteristicBin).Distinct().ToList();
            return result;
        }

        public List<LogisticRegEquationDto> GetLogisticRegEquation()
        {
            var result = (from e in _regEquat.GetAll()
                          select new LogisticRegEquationDto()
                          {
                              Location = e.Location,
                              Resident_Status = e.Resident_Status,
                              Product = e.Product,
                              Current_Account_Status = e.Current_Account_Status,
                              Payment_Performance = e.Payment_Performance,
                              Age_bin = e.Age_bin,
                              Time_at_Job_bin = e.Time_at_Job_bin,
                              Intercept = e.Intercept,
                              Mean_Squared_Error = e.Mean_Squared_Error,
                              Null_Deviance = e.Null_Deviance,
                              R_Square = e.R_Square,
                              Residual_Defiance = e.Residual_Defiance,
                              ROC_AUC = e.ROC_AUC,
                              P_Value = e.P_Value,
                              Degree_of_Freedom = e.Degree_of_Freedom,
                              DF_Predictors = e.DF_Predictors,
                              Degree_of_Freedomb = e.Degree_of_Freedomb,
                              Regression_Defiance = e.Regression_Defiance,
                              Id = e.Id
                          }).ToList();
            return result;
        }
        public CreditScore_PointAllocationDto[] GetPointAllocation(string param)
        {
            var result = (from e in _pointAllocation.GetAll().Where(a=>a.Attribute.Contains(param))
                          select new CreditScore_PointAllocationDto()
                          {
                              Attribute = e.Attribute,
                              Binning = e.Binning,
                              WOE = e.WOE,
                              Score = e.Score,
                              Id = e.Id
                          }).ToArray();
            return result;
        }

        public List<ProfitAnalysisDto> GetProfitAnalysis()
        {
            var result = (from e in _profit.GetAll()
                          select new ProfitAnalysisDto()
                          {
                              CutOff = e.CutOff,
                              TPCount = e.TPCount,
                              FPCount = e.FPCount,
                              Profit = e.Profit,
                              ModelDifference = e.ModelDifference,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<ScalingDto> GetScaling()
        {
            var result = (from e in _scaling.GetAll()
                          select new ScalingDto()
                          {
                              Items = e.Items,
                              Values = e.Values,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<ScoreCardReportDto> GetScoreCardReport()
        {
            var result = (from e in _scorecard.GetAll()
                          select new ScoreCardReportDto()
                          {
                              Characteristic = e.Characteristic,
                              CharacteristicBin = e.CharacteristicBin,
                              ScoreCardPoints = e.ScoreCardPoints,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<ScoreCardScalingDto> GetScoreCardScaling()
        {
            var result = (from e in _scoreCardScalingReport.GetAll()
                          select new ScoreCardScalingDto()
                          {
                              ParameterGroup = e.ParameterGroup,
                              ParameterName = e.ParameterName,
                              Score_After_Regression = e.Score_After_Regression,
                              Score_Card_Point = e.Score_Card_Point,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<ScoreReportDto> GetScoreReport(string search)
        {
            var result = (from e in _report.GetAll().Where(x=>x.Name.Contains(search))
                          select new ScoreReportDto()
                          {
                              Name = e.Name,
                              Characteristic = e.Characteristic,
                              Value = e.Value,
                              Score = e.Score,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public List<string> GetDistinctNames()
        {
            var result = _report.GetAll().Select(x => x.Name).Distinct().ToList();
            return result;
        }

        public List<StabiltyTrendDto> GetStabiltyTrend()
        {

            var result = (from e in _stabilityTrend.GetAll()
                          select new StabiltyTrendDto()
                          {
                              Bins = e.Bins,
                              SampleFrequency = e.SampleFrequency,
                              RecentFrequency = e.RecentFrequency,
                              ThreeMonthFrequency = e.ThreeMonthFrequency,
                              SixMonthFrequency = e.SixMonthFrequency,
                              SixMonthFrequencyPerc = e.SixMonthFrequencyPerc,
                              SampleFrequencyPerc = e.SampleFrequencyPerc,
                              RecentFrequencyPerc = e.RecentFrequencyPerc,
                              ThreeMonthFrequencyPerc = e.ThreeMonthFrequencyPerc,
                          }).ToList();
            return result;
        }

        public List<TblCutOffDto> GetTblCutOff()
        {
            var result = (from e in _cutOff.GetAll()
                          select new TblCutOffDto()
                          {
                              CutOff = e.CutOff,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public async Task<GetScalingForEditOutput> GetScalingForEdit(GetScalingForEditInput input)
        {
            var sc = await _scaling.GetAsync(input.Id);
            return ObjectMapper.Map<GetScalingForEditOutput>(sc);
        }

        public async Task EditScaling(EditScalingInput input)
        {
            var sc = await _scaling.GetAsync(input.Id);
            sc.Items = input.Items;
            sc.Values = input.Values;
            await _scaling.UpdateAsync(sc);
        }

        public async Task<GetTblScoreReportForEditOutput> GetTblScoreReportForEdit(GetTblScoreReportForEditInput input)
        {
            var report = await _scoreReport.GetAsync(input.Id);
            return ObjectMapper.Map<GetTblScoreReportForEditOutput>(report);
        }
        public List<GetTblScoreReportForEditOutput> GetTblScoreReport()
        {
            var res = from e in _scoreReport.GetAll()
                      select new GetTblScoreReportForEditOutput()
                      {
                          CustomerName = e.CustomerName,
                          AccountNumber = e.AccountNumber,
                          TotalScore = e.TotalScore,
                          QualitativeRating = e.QualitativeRating,
                          Id = e.Id
                      };
            return res.ToList();
        }
    }
}
