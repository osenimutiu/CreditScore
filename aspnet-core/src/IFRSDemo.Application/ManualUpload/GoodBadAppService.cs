using Abp.Domain.Repositories;
using IFRSDemo.ManualUpload.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using IFRSDemo.IfrsLoan;

namespace IFRSDemo.ManualUpload
{
    public class GoodBadAppService : IFRSDemoAppServiceBase, IGoodBadAppService
    {
        private readonly IRepository<GoodBad> _goodBad;
        private readonly IApplicationScoringRepository _appScoring;
        public GoodBadAppService(IRepository<GoodBad> goodBad, IApplicationScoringRepository appScoring)
        {
            _goodBad = goodBad;
            _appScoring = appScoring;
        }

        public List<GoodBadDto> GetGoodBadData()
        {
            var result = (from e in _goodBad.GetAll()
                          select new GoodBadDto()
                          {
                              Good = e.Good,
                              Bad = e.Bad,
                              GoodLabel = e.GoodLabel,
                              BadLabel = e.BadLabel,
                              Id = e.Id
                          }).ToList();
            return result;
        }

        public void GetTrain_TestParam(string param)
        {
            _appScoring.GetTrain_TestParam(param);
        }
    }
}
