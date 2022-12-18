using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using System.Collections.Generic;
using System.Collections.Generic;

namespace IFRSDemo.Cooperate
{
    public interface ISetupQualitativesAppService : IApplicationService
    {
        Task<PagedResultDto<GetSetupQualitativeForViewDto>> GetAll(GetAllSetupQualitativesInput input);

        Task<GetSetupQualitativeForViewDto> GetSetupQualitativeForView(int id);

        Task<GetSetupQualitativeForEditOutput> GetSetupQualitativeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSetupQualitativeDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSetupQualitativesToExcel(GetAllSetupQualitativesForExcelInput input);

        Task<List<SetupQualitativeSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown();

        Task<List<SetupQualitativeSetupSubHeadingLookupTableDto>> GetAllSetupSubHeadingForTableDropdown();

        IEnumerable<Object> GetApprovedQualitative(int SubHeadingParam);

        ApiResponseDto InsertNewCoperateScore(string param1, string param2, string param3, double param4);

        IEnumerable<Object> GetDetailScores();

        double GetLatestCooperateScore();




    }
}