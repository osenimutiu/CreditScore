using System;
using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Text;
using System.Data;

namespace IFRSDemo.IfrsLoan
{
   public interface IHistogramRepository : IRepository<Histogram, int>
    {
        //void UpdateRecords();
        string[] GetDistinctTop1Feature();
        string[] GetDistinctFeatures();
        string[] GetCombinations();
        void UpdateRecords(string optVal);
        string GetAllHistogramChart(string ftname);
        DataTable GetHistogramData(string ftname);
        void MaintainSingleRecord();
        void RunDistStat();
    }
}
