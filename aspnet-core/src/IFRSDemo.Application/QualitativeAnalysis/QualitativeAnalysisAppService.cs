using Abp.Application.Services.Dto;
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
    [AbpAuthorize(AppPermissions.Pages_QualitativeAnalysis)]
    public class QualitativeAnalysisAppService : IFRSDemoAppServiceBase, IQualitativeAnalysisAppService
    {
        private readonly IRepository<Tbl_QualitativeAnalysis> _qualitative;
        private readonly IRepository<AttributeItem> _attributeItem;
        private readonly IRepository<Cutoff> _cutoff;
        private readonly IQualitativeAnalysisRepository _qARepository;
        private readonly IRepository<SCMonitoring> _scmonitoring;
        private readonly IRepository<BinRange> _binRange;
        private readonly IRepository<RiskRating> _riskRating;
        private readonly IRepository<QARating> _qaRating;
        private readonly IRepository<RatingAttribute> _ratingAttribute;
        private readonly IRepository<RiskRatingItem> _ratingItem;
        private readonly IRepository<CreateProfit_Analysis> _profAnal;
        private readonly IRepository<tbl_score> _tbl_score;
        private readonly IRepository<PositionInIdustry> _posInd;
        private readonly IRepository<Ownership> _ownership;
        private readonly IRepository<ProductCont> _prodConc;
        private readonly IRepository<Legal> _legal;
        private readonly IRepository<Tbl_Rating> _tblRating;

        public QualitativeAnalysisAppService(IRepository<Tbl_QualitativeAnalysis> qualitative, IRepository<AttributeItem> attributeItem,
                                             IRepository<Cutoff> cutoff, IQualitativeAnalysisRepository qARepository, IRepository<SCMonitoring> scmonitoring,
                                             IRepository<BinRange> binRange, IRepository<RiskRatingItem> ratingItem, IRepository<RiskRating> riskRating, IRepository<QARating> qaRating,
                                             IRepository<RatingAttribute> ratingAttribute, IRepository<CreateProfit_Analysis> profAnal, IRepository<tbl_score> tbl_score,
                                             IRepository<PositionInIdustry> posInd, IRepository<Ownership> ownership, IRepository<ProductCont> prodConc, IRepository<Legal> legal,
                                             IRepository<Tbl_Rating> tblRating)
        {
            _qualitative = qualitative;
            _attributeItem = attributeItem;
            _cutoff = cutoff;
            _qARepository = qARepository;
            _scmonitoring = scmonitoring;
            _binRange = binRange;
            _riskRating = riskRating;
            _qaRating = qaRating;
            _ratingAttribute = ratingAttribute;
            _ratingItem = ratingItem;
            _profAnal = profAnal;
            _tbl_score = tbl_score;
            _posInd = posInd;
            _ownership = ownership;
            _prodConc = prodConc;
            _legal = legal;
            _tblRating = tblRating;
        }
        public Tbl_RatingDto[] GetRating()
        {
            var res = from e in _tblRating.GetAll()
                      select new Tbl_RatingDto()
                      {
                          Rating = e.Rating,
                          Id = e.Id
                      };
            return res.ToArray();
        }
        public async Task createRatingAttribute(CreateRatingAttributeDto input)
        {
            var rating = ObjectMapper.Map<RatingAttribute>(input);
            await _ratingAttribute.InsertAsync(rating);

        }
        public void PreventDuplicateRating()
        {
            _qARepository.PreventDuplicateRating();
        }
        [AbpAuthorize(AppPermissions.Pages_CreateCutOff)]
        public async Task CreateCutOff(CreateCutOffDto input)
        {
            TruncateCutOff();
            var cutOff = ObjectMapper.Map<Cutoff>(input);
            await _cutoff.InsertAsync(cutOff);
        }
        public List<string> GetDistictAttributeItems()
        {
            var dist = _attributeItem.GetAll().Select(x => x.Attributes).Distinct();
            return dist.ToList();
        }

        public AttributeItemDto[] GetAttOption(string search)
        {
            var res = from e in _attributeItem.GetAll().Where(c => c.Attributes.Contains(search))
                      select new AttributeItemDto()
                      {
                          Attributes = e.Attributes,
                          Value = e.Value,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToArray();

        }
        public void TruncateScoresForPost()
        {
            _qARepository.TruncateScoresForPost();
        }
        public async Task PostTotalScore(Createtbl_scoreDto obj)
        {
            var item = ObjectMapper.Map<tbl_score>(obj);
            await _tbl_score.InsertAsync(item);
        }
        public List<tbl_scoreDto> GetSelectedScores()
        {
            var res = from e in _tbl_score.GetAll()
                      select new tbl_scoreDto()
                      {
                          CustomerName = e.CustomerName,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToList();
        }
        public List<PositionInIdustryDto> GetPositionInIdustry()
        {
            var res = from e in _posInd.GetAll()
                      select new PositionInIdustryDto()
                      {
                          Option = e.Option,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToList();
        }
        public List<OwnershipDto> GetOwnership()
        {
            var res = from e in _ownership.GetAll()
                      select new OwnershipDto()
                      {
                          Option = e.Option,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToList();
        }
        public List<ProductContDto> GetProductCont()
        {
            var res = from e in _prodConc.GetAll()
                      select new ProductContDto()
                      {
                          Option = e.Option,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToList();
        }
        public List<LegalDto> GetLegal()
        {
            var res = from e in _legal.GetAll()
                      select new LegalDto()
                      {
                          Option = e.Option,
                          Score = e.Score,
                          Id = e.Id
                      };
            return res.ToList();
        }
        public void ObtainOption()
        {
            _qARepository.ObtainOption();
        }
        
        public AttributeItemDto[] GetAttributeItem()
        {
            var result = from e in _attributeItem.GetAll()
                         select new AttributeItemDto()
                         {
                             Attributes = e.Attributes,
                             Value = e.Value,
                             Score = e.Score,
                             Id = e.Id
                         };
            return result.ToArray();
        }

       
        public CutoffDto[] GetCutoff()
        {
            var result = from e in _cutoff.GetAll()
                         select new CutoffDto()
                         {
                             CutoffValue = e.CutoffValue,
                             Id = e.Id
                         };
            return result.ToArray();
        }

        
        public Tbl_QualitativeAnalysisDto[] GetQualitativeAnalysis()
        {
            var result = from e in _qualitative.GetAll()
                         select new Tbl_QualitativeAnalysisDto()
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
        [AbpAuthorize(AppPermissions.Pages_PostQualitativeAnalysis)]
        public async Task PostQualitativeAnalysis(CreateQualitativeAnalysisDto input)
        {
            var qual = ObjectMapper.Map<Tbl_QualitativeAnalysis>(input);
            await _qualitative.InsertAsync(qual);
        }

        public void TruncateCutOff()
        {
            _qARepository.TruncateCutOff();
        }

        public async Task Delete(EntityDto del)
        {
            await _qualitative.DeleteAsync(del.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_GetSCMonitoring)]
        public SCMonitoringDto[] GetSCMonitoring()
        {
            var result = from e in _scmonitoring.GetAll()
                         join f in _binRange.GetAll() on e.Bin_name equals f.Id
                         select new SCMonitoringDto()
                         {
                             Scores = e.Scores,
                             Bin_name = f.Range,
                             Approved = e.Approved,
                             Rejected = e.Rejected,
                             Id = e.Id
                         };
            return result.ToArray();
        }
        public BinRangeDto[] GetBinRange()
        {
            var result = from e in _binRange.GetAll()
                         select new BinRangeDto()
                         {
                             Range = e.Range,
                             Id = e.Id
                         };
            return result.ToArray();
        }
        public async Task CreateSCMonitoring(CreateSCMonitoringDto input)
        {
            input.Approved = false;
            input.Rejected = false;
            var qaRat = ObjectMapper.Map<SCMonitoring>(input);
            await _scmonitoring.InsertAsync(qaRat);
        }
        public async Task DeleteSCMonitoring(int id)
        {
            await _scmonitoring.DeleteAsync(id);
        }
       
        public QARatingDto[] GetQARating()
        {
            var result = from e in _qaRating.GetAll()
                         select new QARatingDto()
                         {
                             Rating = e.Rating,
                             RatingDescription = e.RatingDescription,
                             Score = e.Score,
                             Range = e.Range,
                             Id = e.Id
                         };
            return result.ToArray();
        }

        //for cooperate scorecard
        public QARatingDto[] RateCooperateUser(int cooperatescore)
        {
            var result = from e in _qaRating.GetAll().Where(x => x.Score <= cooperatescore && x.Range >= cooperatescore)
                         select new QARatingDto()
                         {
                             Rating = e.Rating,
                             RatingDescription = e.RatingDescription,
                             Score = e.Score,
                             Range = e.Range,
                             Id = e.Id
                         };
            return result.ToArray();

        }

        public async Task<GetQARatingForEditOutput> GetQARatingEdit(GetQARatingForEditInput input)
        {
            var qaRating = await _qaRating.GetAsync(input.Id);
            return ObjectMapper.Map<GetQARatingForEditOutput>(qaRating);
        }
        public async Task EditQARating(EditQARatingInput input)
        {
            var qaRating = await _qaRating.GetAsync(input.Id);
            qaRating.Rating = input.Rating;
            qaRating.RatingDescription = input.RatingDescription;
            qaRating.Score = input.Score;
            qaRating.Range = input.Range;
            await _qaRating.UpdateAsync(qaRating);
        }
        public async Task CreateQARating(CreateQARatingDto input)
        {
            var qaRat = ObjectMapper.Map<QARating>(input);
            await _qaRating.InsertAsync(qaRat);
        }
        public async Task DeleteQARating(int id)
        {
            await _qaRating.DeleteAsync(id);
        }
        public RatingAttributeDto[] GetRatingAttribute()
        {
            var result = from e in _ratingAttribute.GetAll()
                         select new RatingAttributeDto()
                         {
                             Items = e.Items,
                             Id = e.Id
                         };
            return result.ToArray();
        }
        public RiskRatingItemDto[] GetRiskRatingItem(string cat)
        {
            var result = from e in _ratingItem.GetAll().Where(x => x.Category.Contains(cat))
                         select new RiskRatingItemDto()
                         {
                             Category = e.Category,
                             Option = e.Option,
                             Score = e.Score,
                             Id = e.Id
                         };
            return result.ToArray();
        }
        public async Task CreateProfitAnalysis(CreateProfit_AnalysisDto input)  
        {
            input.Loss = -1;
            var pa = ObjectMapper.Map<CreateProfit_Analysis>(input);
            await _profAnal.InsertAsync(pa);
        }
    }
}
