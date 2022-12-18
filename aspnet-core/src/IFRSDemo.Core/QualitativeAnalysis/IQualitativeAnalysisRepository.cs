using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
    public interface IQualitativeAnalysisRepository : IRepository<Tbl_QualitativeAnalysis, int>
    {
        void TruncateCutOff();
        void TruncateRetailCutOff();
        void TruncateScoresForPost();
        void ObtainOption();
        void PreventDuplicateRating();
    }
}
