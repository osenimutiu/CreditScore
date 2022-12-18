using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using IFRSDemo.IfrsLoan.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IApplicationScoringAppService : IApplicationService
    {
        Task CreateApplicationScoring(CreateApplicationScoringInput input);
        Task<PagedResultDto<ApplicationScoringListDto>> GetApplicationScoring(GetApplicationScoringInput input);
         void ComputeFirstApplicationScore(int param1, int param2, int param3, int param4, int param5, int param6, int param7, string param8, string param9, int param10);
         void ComputeSecondApplicationScore(string param11, string param9, string custid, int param10);
    }
}
