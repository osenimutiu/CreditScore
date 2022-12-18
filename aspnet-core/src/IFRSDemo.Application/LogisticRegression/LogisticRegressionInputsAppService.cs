using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using IFRSDemo.LogisticRegression.Exporting;
using IFRSDemo.LogisticRegression.Dtos;
using IFRSDemo.Dto;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.LogisticRegression
{
    [AbpAuthorize(AppPermissions.Pages_LogisticRegressionInputs)]
    public class LogisticRegressionInputsAppService : IFRSDemoAppServiceBase, ILogisticRegressionInputsAppService
    {
        private readonly IRepository<LogisticRegressionInput> _logisticRegressionInputRepository;
        private readonly ILogisticRegressionInputsExcelExporter _logisticRegressionInputsExcelExporter;

        public LogisticRegressionInputsAppService(IRepository<LogisticRegressionInput> logisticRegressionInputRepository, ILogisticRegressionInputsExcelExporter logisticRegressionInputsExcelExporter)
        {
            _logisticRegressionInputRepository = logisticRegressionInputRepository;
            _logisticRegressionInputsExcelExporter = logisticRegressionInputsExcelExporter;

        }

        public async Task<PagedResultDto<GetLogisticRegressionInputForViewDto>> GetAll(GetAllLogisticRegressionInputsInput input)
        {

            var filteredLogisticRegressionInputs = _logisticRegressionInputRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(input.MinLocationFilter != null, e => e.Location >= input.MinLocationFilter)
                        .WhereIf(input.MaxLocationFilter != null, e => e.Location <= input.MaxLocationFilter)
                        .WhereIf(input.MinRent_binFilter != null, e => e.Rent_bin >= input.MinRent_binFilter)
                        .WhereIf(input.MaxRent_binFilter != null, e => e.Rent_bin <= input.MaxRent_binFilter)
                        .WhereIf(input.MinRent_to_Income_binFilter != null, e => e.Rent_to_Income_bin >= input.MinRent_to_Income_binFilter)
                        .WhereIf(input.MaxRent_to_Income_binFilter != null, e => e.Rent_to_Income_bin <= input.MaxRent_to_Income_binFilter)
                        .WhereIf(input.MinReturn_on_Assets_binFilter != null, e => e.Return_on_Assets_bin >= input.MinReturn_on_Assets_binFilter)
                        .WhereIf(input.MaxReturn_on_Assets_binFilter != null, e => e.Return_on_Assets_bin <= input.MaxReturn_on_Assets_binFilter)
                        .WhereIf(input.MinTotal_assets_binFilter != null, e => e.Total_assets_bin >= input.MinTotal_assets_binFilter)
                        .WhereIf(input.MaxTotal_assets_binFilter != null, e => e.Total_assets_bin <= input.MaxTotal_assets_binFilter)
                        .WhereIf(input.Good_BadFilter.HasValue && input.Good_BadFilter > -1, e => (input.Good_BadFilter == 1 && e.Good_Bad) || (input.Good_BadFilter == 0 && !e.Good_Bad))
                        .WhereIf(input.Training_TestFilter.HasValue && input.Training_TestFilter > -1, e => (input.Training_TestFilter == 1 && e.Training_Test) || (input.Training_TestFilter == 0 && !e.Training_Test));


            var pagedAndFilteredLogisticRegressionInputs = filteredLogisticRegressionInputs
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var logisticRegressionInputs = from o in pagedAndFilteredLogisticRegressionInputs
                                           select new GetLogisticRegressionInputForViewDto()
                                           {
                                               LogisticRegressionInput = new LogisticRegressionInputDto
                                               {
                                                   Location = o.Location,
                                                   Rent_bin = o.Rent_bin,
                                                   Rent_to_Income_bin = o.Rent_to_Income_bin,
                                                   Return_on_Assets_bin = o.Return_on_Assets_bin,
                                                   Total_assets_bin = o.Total_assets_bin,
                                                   Good_Bad = o.Good_Bad,
                                                   Training_Test = o.Training_Test,
                                                   Id = o.Id
                                               }
                                           };

            var totalCount = await filteredLogisticRegressionInputs.CountAsync();

            return new PagedResultDto<GetLogisticRegressionInputForViewDto>(
                totalCount,
                await logisticRegressionInputs.ToListAsync()
            );
        }

        public async Task<GetLogisticRegressionInputForViewDto> GetLogisticRegressionInputForView(int id)
        {
            var logisticRegressionInput = await _logisticRegressionInputRepository.GetAsync(id);

            var output = new GetLogisticRegressionInputForViewDto { LogisticRegressionInput = ObjectMapper.Map<LogisticRegressionInputDto>(logisticRegressionInput) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LogisticRegressionInputs_Edit)]
        public async Task<GetLogisticRegressionInputForEditOutput> GetLogisticRegressionInputForEdit(EntityDto input)
        {
            var logisticRegressionInput = await _logisticRegressionInputRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLogisticRegressionInputForEditOutput { LogisticRegressionInput = ObjectMapper.Map<CreateOrEditLogisticRegressionInputDto>(logisticRegressionInput) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditLogisticRegressionInputDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_LogisticRegressionInputs_Create)]
        protected virtual async Task Create(CreateOrEditLogisticRegressionInputDto input)
        {
            var logisticRegressionInput = ObjectMapper.Map<LogisticRegressionInput>(input);

            if (AbpSession.TenantId != null)
            {
                logisticRegressionInput.TenantId = (int?)AbpSession.TenantId;
            }

            await _logisticRegressionInputRepository.InsertAsync(logisticRegressionInput);
        }

        [AbpAuthorize(AppPermissions.Pages_LogisticRegressionInputs_Edit)]
        protected virtual async Task Update(CreateOrEditLogisticRegressionInputDto input)
        {
            var logisticRegressionInput = await _logisticRegressionInputRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, logisticRegressionInput);
        }

        [AbpAuthorize(AppPermissions.Pages_LogisticRegressionInputs_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _logisticRegressionInputRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetLogisticRegressionInputsToExcel(GetAllLogisticRegressionInputsForExcelInput input)
        {

            var filteredLogisticRegressionInputs = _logisticRegressionInputRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(input.MinLocationFilter != null, e => e.Location >= input.MinLocationFilter)
                        .WhereIf(input.MaxLocationFilter != null, e => e.Location <= input.MaxLocationFilter)
                        .WhereIf(input.MinRent_binFilter != null, e => e.Rent_bin >= input.MinRent_binFilter)
                        .WhereIf(input.MaxRent_binFilter != null, e => e.Rent_bin <= input.MaxRent_binFilter)
                        .WhereIf(input.MinRent_to_Income_binFilter != null, e => e.Rent_to_Income_bin >= input.MinRent_to_Income_binFilter)
                        .WhereIf(input.MaxRent_to_Income_binFilter != null, e => e.Rent_to_Income_bin <= input.MaxRent_to_Income_binFilter)
                        .WhereIf(input.MinReturn_on_Assets_binFilter != null, e => e.Return_on_Assets_bin >= input.MinReturn_on_Assets_binFilter)
                        .WhereIf(input.MaxReturn_on_Assets_binFilter != null, e => e.Return_on_Assets_bin <= input.MaxReturn_on_Assets_binFilter)
                        .WhereIf(input.MinTotal_assets_binFilter != null, e => e.Total_assets_bin >= input.MinTotal_assets_binFilter)
                        .WhereIf(input.MaxTotal_assets_binFilter != null, e => e.Total_assets_bin <= input.MaxTotal_assets_binFilter)
                        .WhereIf(input.Good_BadFilter.HasValue && input.Good_BadFilter > -1, e => (input.Good_BadFilter == 1 && e.Good_Bad) || (input.Good_BadFilter == 0 && !e.Good_Bad))
                        .WhereIf(input.Training_TestFilter.HasValue && input.Training_TestFilter > -1, e => (input.Training_TestFilter == 1 && e.Training_Test) || (input.Training_TestFilter == 0 && !e.Training_Test));


            var query = (from o in filteredLogisticRegressionInputs
                         select new GetLogisticRegressionInputForViewDto()
                         {
                             LogisticRegressionInput = new LogisticRegressionInputDto
                             {
                                 Location = o.Location,
                                 Rent_bin = o.Rent_bin,
                                 Rent_to_Income_bin = o.Rent_to_Income_bin,
                                 Return_on_Assets_bin = o.Return_on_Assets_bin,
                                 Total_assets_bin = o.Total_assets_bin,
                                 Good_Bad = o.Good_Bad,
                                 Training_Test = o.Training_Test,
                                 Id = o.Id
                             }
                         });

            var logisticRegressionInputListDtos = await query.ToListAsync();

            return _logisticRegressionInputsExcelExporter.ExportToFile(logisticRegressionInputListDtos);
        }

    }
}