using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IRatingPredictionOutputAppService : IApplicationService
    {
        ListResultDto<RatingPredictionOutputListDto> GetRatingPredictionOutput(GetRatingPredictionOutputInput input);
    }
}
