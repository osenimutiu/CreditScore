using Abp.Application.Services;
using IFRSDemo.ManualUpload.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.ManualUpload
{
    public interface IGoodBadAppService : IApplicationService
    {
        List<GoodBadDto> GetGoodBadData();
        void GetTrain_TestParam(string param);
       
    }
}
