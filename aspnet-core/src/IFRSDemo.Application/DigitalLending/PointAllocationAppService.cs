using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace IFRSDemo.DigitalLending
{
    public class PointAllocationAppService : IFRSDemoAppServiceBase, IPointAllocationAppService
    {
        private readonly IRepository<PointAllocationByScore> _score;
        private readonly IRepository<PointAllocationByDetail> _detail;
        private readonly ISeverityRepository _severity;
        public PointAllocationAppService(IRepository<PointAllocationByScore> score, IRepository<PointAllocationByDetail> detail, ISeverityRepository severity)
        {
            _score = score;
            _detail = detail;
            _severity = severity;
        }

        public IEnumerable<Object> GetAllocationByDetails()
        {
            var result = (from o in _detail.GetAll() select new
            {
                Id = o.Id,
                RefNo = o.Refno,
                Characteristics = o.Characteristic,
                Attribute = o.Attribute,
                Score = o.Score,
            });
            return result.ToList();
        }

        public IEnumerable<Object> GetAllocationByScores()
        {
            var result = (from o in _score.GetAll()
                          select new
                          {
                              Id = o.Id,
                              RefNo = o.Refno,
                              Characteristic = o.Characteristic,
                              Attribute = o.Attribute,
                              Score = o.Score,
                          });
            return result.ToList();
        }
        public void GenerateScoreAllocation()
        {
             _severity.GenerateScoreAllocation();
        }
    }
}
