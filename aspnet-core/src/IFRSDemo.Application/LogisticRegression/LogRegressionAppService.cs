using Abp.Authorization;
using Abp.Domain.Repositories;
using IFRSDemo.Authorization;
using IFRSDemo.IfrsLoan;
using IFRSDemo.LogisticRegression.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
    [AbpAuthorize(AppPermissions.Pages_LogRegression)]
    public class LogRegressionAppService : IFRSDemoAppServiceBase, ILogRegressionAppService
    {
        private readonly IRepository<LogRegression> _repo;
        private readonly IApplicationScoringRepository _appRepo;
        private readonly IRepository<LogisticRegressionOutput> _logRegOutputRepo;

        public LogRegressionAppService(IRepository<LogRegression> repo, IApplicationScoringRepository appRepo, IRepository<LogisticRegressionOutput> logRegOutputRepo)
        {
            _repo = repo;
            _appRepo = appRepo;
            _logRegOutputRepo = logRegOutputRepo;
        }

        public List<GetLogRegressionForViewDto> GetAll()
        {
            var regression = _repo.GetAll().ToList();
            return new List<GetLogRegressionForViewDto>(ObjectMapper.Map<List<GetLogRegressionForViewDto>>(regression));
        }

        public LogisticRegressionOutputDto[] GetAllLogisticRegressionOutput()
        {
            var joinTable = (from obj in _logRegOutputRepo.GetAll()
                             select new LogisticRegressionOutputDto()
                             {
                                 coefficients = obj.coefficients,
                                 name = obj.name,
                                 Id = obj.Id
                             }).ToArray();
            return joinTable;
        }

        public List<GetLogRegressionForViewDto> GetRegressionBySearch(string training_Test)
        {
            var joinTable = (from obj in _repo.GetAll().Where(t => t.Training_Test.Contains(training_Test))

                             select new GetLogRegressionForViewDto()
                             {
                                 Location = obj.Location,
                                 Rent_bin = obj.Rent_bin,
                                 Rent_to_Income_bin = obj.Rent_to_Income_bin,
                                 Return_on_Assets_bin = obj.Return_on_Assets_bin,
                                 Id = obj.Id,
                                 Total_assets_bin = obj.Total_assets_bin,
                                 Good_Bad = obj.Good_Bad,
                                 Training_Test = obj.Training_Test
                             }).ToList();
            return new List<GetLogRegressionForViewDto>(ObjectMapper.Map<List<GetLogRegressionForViewDto>>(joinTable));

        }

        public void PostForAllRegression()
        {
            _appRepo.PostForAllRegression();
        }
    }
}
