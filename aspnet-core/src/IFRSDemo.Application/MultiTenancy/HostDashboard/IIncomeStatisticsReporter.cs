using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IFRSDemo.MultiTenancy.HostDashboard.Dto;

namespace IFRSDemo.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}