using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    public interface IPointAllocationAppService : IApplicationService
    {
        IEnumerable<Object> GetAllocationByScores();
        IEnumerable<Object> GetAllocationByDetails();
        void GenerateScoreAllocation();
    }
}
