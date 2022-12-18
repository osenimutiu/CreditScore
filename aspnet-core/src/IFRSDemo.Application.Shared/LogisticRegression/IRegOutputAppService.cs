using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.LogisticRegression.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.LogisticRegression
{
    public interface IRegOutputAppService : IApplicationService
    {
        Task<PagedResultDto<RegOutputDto>> GetAll(GetAllRegOutputInput input);
        List<RegOutputRunDataDto> GetLastRunDate();
        void InserRunDate();

    }
}
