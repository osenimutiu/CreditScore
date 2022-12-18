using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using System;
using System.Collections.Generic;
using Abp.Linq.Extensions;
using Abp.Authorization;
using IFRSDemo.Authorization;
using System.Text;
using IFRSDemo.IfrsLoan.Dto;
namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_RatingPredictionOutput)]
    public class RatingPredictionOutputAppService : IFRSDemoAppServiceBase, IRatingPredictionOutputAppService
    {
        private readonly IRepository<RatingPredictionOutput> _ratingPredictionOutputRepository;
        public RatingPredictionOutputAppService(IRepository<RatingPredictionOutput> ratingPredictionOutputRepository)
        {
            _ratingPredictionOutputRepository = ratingPredictionOutputRepository;
        }

        public ListResultDto<RatingPredictionOutputListDto> GetRatingPredictionOutput(GetRatingPredictionOutputInput input)
        {
            var ratingPredictionOutputs = _ratingPredictionOutputRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                 
                       p =>  p.Name.Contains(input.Filter) ||
                        p.Score.ToString().Contains(input.Filter) ||
                        p.Risk_Level.Contains(input.Filter) ||
                        p.PD.ToString().Contains(input.Filter) ||
                        p.Good_Bad_Odd.ToString().Contains(input.Filter) ||
                        p.Debt_Income_Ratio.ToString().Contains(input.Filter) ||
                        p.Interest_Rate.ToString().Contains(input.Filter) ||
                        p.Recommendation.Contains(input.Filter) 
               )
               .OrderBy(p => p.Name)
               .ThenBy(p => p.Risk_Level)
               .ToList();

            return new ListResultDto<RatingPredictionOutputListDto>(ObjectMapper.Map<List<RatingPredictionOutputListDto>>(ratingPredictionOutputs));

        }

    }
}
