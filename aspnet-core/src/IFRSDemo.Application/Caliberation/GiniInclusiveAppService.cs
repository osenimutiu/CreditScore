using Abp.Domain.Repositories;
using IFRSDemo.Caliberation.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Abp.Authorization;
using IFRSDemo.Authorization;
using System.Threading.Tasks;

namespace IFRSDemo.Caliberation
{
    [AbpAuthorize(AppPermissions.Pages_Caliberation)]
    public class GiniInclusiveAppService : IFRSDemoAppServiceBase, IGiniInclusiveAppService
    {
        private readonly IRepository<GiniInclusive> _giniInclusive;
        private readonly IRepository<CalibrationC> _caliberation;
        private readonly IRepository<SetupPage> _setup;
        private readonly IRepository<VintageAnalysis> _vintage;
        public GiniInclusiveAppService(IRepository<GiniInclusive> giniInclusive, IRepository<CalibrationC> caliberation, IRepository<SetupPage> setup,
                                       IRepository<VintageAnalysis> vintage)
        {
            _giniInclusive = giniInclusive;
            _caliberation = caliberation;
            _setup = setup;
            _vintage = vintage;
        }

        [AbpAuthorize(AppPermissions.Pages_SetUpPage)]
        public async Task CreateSetUp(CreateSetUPDto input)
        {
            var setUp = ObjectMapper.Map<SetupPage>(input);
            await _setup.InsertAsync(setUp);
        }

        public CalibrationCDto[] GetCalibrations()
        {

            var res = (from e in _caliberation.GetAll()
                       select new CalibrationCDto()
                       {
                           Rating = e.Rating,
                           PercPD_real = e.PercPD_real,
                           PD_real = e.PD_real,
                           NOC = e.NOC,
                           NOD = e.NOD,
                           ScoreRanges = e.ScoreRanges,
                           Odds = e.Odds,
                           PercPD_Odds = e.PercPD_Odds,
                           PD_Odds = e.PD_Odds,
                           Xr = e.Xr,
                           PercPD_est = e.PercPD_est,
                           PD_est = e.PD_est,
                           High = e.High,
                           Low = e.Low,
                           BinomialTestSP = e.BinomialTestSP,
                           BinomialTestOdds = e.BinomialTestOdds,
                           Id = e.Id
                       }).ToArray();
            return res;
        }

        public List<GiniInclusiveDto> GetGiniInclusives()
        {
            var res = from e in _giniInclusive.GetAll()
                      select new GiniInclusiveDto()
                      {
                          Good_Bad = e.Good_Bad,
                          Score = e.Score,
                          CumNoDefaulters = e.CumNoDefaulters,
                          CumNoApplicants = e.CumNoApplicants,
                          CumPercDefaulters = e.CumPercDefaulters,
                          CumPercApplicants = e.CumPercApplicants,
                          AreaUnderCAP = e.AreaUnderCAP,
                          Y_fit = e.Y_fit,
                          Residual = e.Residual,
                          ResSquare = e.ResSquare,
                          Id = e.Id
                      };
            return res.ToList();
        }

        public SetuPPageDto[] GetSetUp()
        {
            var res = (from e in _setup.GetAll()
                       select new SetuPPageDto()
                       {
                           CreditScoreWeight = e.CreditScoreWeight,
                           QualitativeAnalysisWeight = e.QualitativeAnalysisWeight,
                           Id = e.Id
                       }).OrderByDescending(x=>x.Id).Take(1).ToArray();
            return res;
        }
        [AbpAuthorize(AppPermissions.Pages_VintageAnalysis)]
        public VintageAnalysisDto[] GetVintageAnalysis()
        {
            var res = (from e in _vintage.GetAll()
                       select new VintageAnalysisDto()
                       {
                           FullDate = e.FullDate,
                           FullYear = e.FullYear,
                           FullMonth = e.FullMonth,
                           FullCount = e.FullCount,
                           Q1 = e.Q1,
                           Q2 = e.Q2,
                           Q3 = e.Q3,
                           Q4 = e.Q4,
                           Q5 = e.Q5,
                           Q6 = e.Q6,
                           Q7 = e.Q7,
                           Q8 = e.Q8,
                           Q9 = e.Q9,
                           Q10 = e.Q10,
                           Q11 = e.Q11,
                           Q12 = e.Q12,
                           Id = e.Id
                       }).ToArray();
            return res;
        }
    }
}
