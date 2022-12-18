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
    [AbpAuthorize(AppPermissions.Pages_Tenant_AllScore)]
    public class AllScoreAppService : IFRSDemoAppServiceBase, IAllScoreAppService
    {
        private readonly IRepository<AllScore> _allScoreRepository;
        public AllScoreAppService(IRepository<AllScore> allScoreRepository)
        {
            _allScoreRepository = allScoreRepository;
        }

        public ListResultDto<AllScoreListDto> GetAllScore(GetAllScoreInput input)
        {
            var allScores = _allScoreRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                           p => p.Group.Contains(input.Filter) ||
                           p.Pd.ToString().Contains(input.Filter) ||
                           p.Score.ToString().Contains(input.Filter) ||
                           p.Item.ToString().Contains(input.Filter) ||
                           p.ItemName.Contains(input.Filter)

               )
               .OrderBy(p => p.Group)
               .ThenBy(p => p.ItemName)
               .ToList();

            return new ListResultDto<AllScoreListDto>(ObjectMapper.Map<List<AllScoreListDto>>(allScores));

        }
    }
}
