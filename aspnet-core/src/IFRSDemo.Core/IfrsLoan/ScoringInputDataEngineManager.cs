using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;


namespace IFRSDemo.IfrsLoan
{
   public class ScoringInputDataEngineManager : IFRSDemoDomainServiceBase, IScoringInputDataEngineManager
    {
        private readonly IRepository<ScoringInputData> _scoringInputData;

        public ScoringInputDataEngineManager(IRepository<ScoringInputData> scoringInputData)
        {

            _scoringInputData = scoringInputData;
            
        }

        public void CreateScoringInputData(List<ScoringInputData> input)
        {

            var context = _scoringInputData.GetDbContext();

            try
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.Set<ScoringInputData>().AddRange(input);
                context.BulkSaveChanges();

            }
            finally
            {
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }

        }

        public void UpdateScoringInputDataAsync(ScoringInputData input)
        {
            var context = _scoringInputData.GetDbContext();

            try
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.Set<ScoringInputData>().UpdateRange(input);
                context.BulkSaveChanges();

            }
            finally
            {
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public async Task<List<ScoringInputData>> GetListScoringInputData()
        {
            var item = await _scoringInputData.GetAllListAsync();
            return item;
        }

    }
}
