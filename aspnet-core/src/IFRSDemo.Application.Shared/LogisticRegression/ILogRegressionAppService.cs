using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.LogisticRegression.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
   public interface ILogRegressionAppService : IApplicationService
    {
        List<GetLogRegressionForViewDto> GetAll();
        List<GetLogRegressionForViewDto> GetRegressionBySearch(string training_Test);
        void PostForAllRegression();
        LogisticRegressionOutputDto[] GetAllLogisticRegressionOutput();

    }
}
