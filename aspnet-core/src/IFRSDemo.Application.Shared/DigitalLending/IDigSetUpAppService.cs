using Abp.Application.Services;
using IFRSDemo.DigitalLending.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.DigitalLending
{
   public interface IDigSetUpAppService : IApplicationService
    {
        Task<GetDigSetUpForEditOutput> GetDigSetUpEdit(GetDigSetUpForEditInput input);
        Task EditDigSetUp(EditDigSetUpInput input);
        DigSetUpDto[] GetDigLendSetUp();
        DigSetUpDto[] GetDigLendSetUpForExport();
    }
}
