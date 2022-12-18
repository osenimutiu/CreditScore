using Abp.Authorization;
using Abp.Domain.Repositories;
using IFRSDemo.Authorization;
using IFRSDemo.QualitativeAnalysis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
    [AbpAuthorize(AppPermissions.Pages_RetailScoring)]
    public class RetailScoringAppService : IFRSDemoAppServiceBase, IRetailScoringAppService
    {
        private readonly IRepository<RetailAttrItem, int> _retailItem;
        private readonly IRepository<RetailScoring, int> _retailScoring;
        private readonly IRepository<RetailCutoff, int> _retailCutOff;
        private readonly IQualitativeAnalysisRepository _qualitAnls;

        public RetailScoringAppService(IRepository<RetailAttrItem, int> retailItem, IRepository<RetailScoring, int> retailScoring,
                                        IRepository<RetailCutoff, int> retailCutOff, IQualitativeAnalysisRepository qualitAnls)
        {
            _retailItem = retailItem;
            _retailScoring = retailScoring;
            
            _retailCutOff = retailCutOff;
            _qualitAnls = qualitAnls;
        }

        [AbpAuthorize(AppPermissions.Pages_GetRetailCutoff)]
        public RetailCutoffDto[] GetRetailCutoff()
        {
            var result = from e in _retailCutOff.GetAll()
                         select new RetailCutoffDto()
                         {
                             CutoffValue = e.CutoffValue,
                             Id = e.Id
                         };
            return result.ToArray();
        }

        public RetailItemDto[] GetRetailItem()
        {
            var result = from e in _retailItem.GetAll()
                         select new RetailItemDto()
                         {
                             Attributes = e.Attributes,
                             Value = e.Value,
                             Score = e.Score,
                             Id = e.Id
                         };
            return result.ToArray();
        }
        public RetailItemDto[] GetAttOption(string search)
        {
            var res = from e in _retailItem.GetAll().Where(c => c.Attributes.Contains(search))
                      select new RetailItemDto()
                      {
                          Attributes = e.Attributes,
                          Value = e.Value,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToArray();
        }
        [AbpAuthorize(AppPermissions.Pages_GetRetailScoring)]
        public RetailScoringDto[] GetRetailScoring()
        {
            var result = from e in _retailScoring.GetAll() 
                         select new RetailScoringDto()
                         {
                             Attribute = e.Attribute,
                             Weight = e.Weight,
                             Percentage = e.Percentage,
                             MaxScore = e.MaxScore,
                             Value = e.Value,
                             AttributeScore = e.AttributeScore,
                             WeightedAttribute = e.WeightedAttribute,
                             Id = e.Id
                         };
            return result.ToArray();
        }

        [AbpAuthorize(AppPermissions.Pages_PostRetailCutoff)]
        public async Task PostRetailCutoff(CreateRetailCutOff input)
        {
            TruncateRetailCutOff();
            var cutOff = ObjectMapper.Map<RetailCutoff>(input);
            await _retailCutOff.InsertAsync(cutOff);
        }
        public List<string> GetDistictAttributeItems()
        {
            var dist = _retailItem.GetAll().Select(x => x.Attributes).Distinct();
            return dist.ToList();
        }
        [AbpAuthorize(AppPermissions.Pages_PostRetailScoring)]
        public async Task PostRetailScoring(CreateRetailScoring input)
        {
            var scoring = ObjectMapper.Map<RetailScoring>(input);
            await _retailScoring.InsertAsync(scoring);
        }

        public void TruncateRetailCutOff()
        {
            _qualitAnls.TruncateRetailCutOff();
        }
        public async Task DeteteRetailScoring(int id)
        {
            await _retailScoring.DeleteAsync(id);
        }
    }
}
