using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using IFRSDemo.Regression.Exporting;
using IFRSDemo.Regression.Dtos;
using IFRSDemo.Dto;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.Regression
{
    [AbpAuthorize(AppPermissions.Pages_RegressionOutputs)]
    public class RegressionOutputsAppService : IFRSDemoAppServiceBase, IRegressionOutputsAppService
    {
        private readonly IRepository<RegressionOutput> _regressionOutputRepository;
        private readonly IRegressionOutputsExcelExporter _regressionOutputsExcelExporter;

        public RegressionOutputsAppService(IRepository<RegressionOutput> regressionOutputRepository, IRegressionOutputsExcelExporter regressionOutputsExcelExporter)
        {
            _regressionOutputRepository = regressionOutputRepository;
            _regressionOutputsExcelExporter = regressionOutputsExcelExporter;

        }

        public async Task<PagedResultDto<GetRegressionOutputForViewDto>> GetAll(GetAllRegressionOutputsInput input)
        {

            var filteredRegressionOutputs = _regressionOutputRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ParamName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParamNameFilter), e => e.ParamName == input.ParamNameFilter)
                        .WhereIf(input.MinCoeff_EstimateFilter != null, e => e.Coeff_Estimate >= input.MinCoeff_EstimateFilter)
                        .WhereIf(input.MaxCoeff_EstimateFilter != null, e => e.Coeff_Estimate <= input.MaxCoeff_EstimateFilter)
                        .WhereIf(input.MinStd_ErrorFilter != null, e => e.Std_Error >= input.MinStd_ErrorFilter)
                        .WhereIf(input.MaxStd_ErrorFilter != null, e => e.Std_Error <= input.MaxStd_ErrorFilter)
                        .WhereIf(input.Mint_valueFilter != null, e => e.t_value >= input.Mint_valueFilter)
                        .WhereIf(input.Maxt_valueFilter != null, e => e.t_value <= input.Maxt_valueFilter)
                        .WhereIf(input.Minp_valueFilter != null, e => e.p_value >= input.Minp_valueFilter)
                        .WhereIf(input.Maxp_valueFilter != null, e => e.p_value <= input.Maxp_valueFilter);

            var pagedAndFilteredRegressionOutputs = filteredRegressionOutputs
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var regressionOutputs = from o in pagedAndFilteredRegressionOutputs
                                    select new GetRegressionOutputForViewDto()
                                    {
                                        RegressionOutput = new RegressionOutputDto
                                        {
                                            ParamName = o.ParamName,
                                            Coeff_Estimate = o.Coeff_Estimate,
                                            Std_Error = o.Std_Error,
                                            t_value = o.t_value,
                                            p_value = o.p_value,
                                            Id = o.Id
                                        }
                                    };

            var totalCount = await filteredRegressionOutputs.CountAsync();

            return new PagedResultDto<GetRegressionOutputForViewDto>(
                totalCount,
                await regressionOutputs.ToListAsync()
            );
        }

        public async Task<GetRegressionOutputForViewDto> GetRegressionOutputForView(int id)
        {
            var regressionOutput = await _regressionOutputRepository.GetAsync(id);

            var output = new GetRegressionOutputForViewDto { RegressionOutput = ObjectMapper.Map<RegressionOutputDto>(regressionOutput) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_RegressionOutputs_Edit)]
        public async Task<GetRegressionOutputForEditOutput> GetRegressionOutputForEdit(EntityDto input)
        {
            var regressionOutput = await _regressionOutputRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetRegressionOutputForEditOutput { RegressionOutput = ObjectMapper.Map<CreateOrEditRegressionOutputDto>(regressionOutput) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditRegressionOutputDto input)
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

        [AbpAuthorize(AppPermissions.Pages_RegressionOutputs_Create)]
        protected virtual async Task Create(CreateOrEditRegressionOutputDto input)
        {
            var regressionOutput = ObjectMapper.Map<RegressionOutput>(input);

            if (AbpSession.TenantId != null)
            {
                regressionOutput.TenantId = (int?)AbpSession.TenantId;
            }

            await _regressionOutputRepository.InsertAsync(regressionOutput);
        }

        [AbpAuthorize(AppPermissions.Pages_RegressionOutputs_Edit)]
        protected virtual async Task Update(CreateOrEditRegressionOutputDto input)
        {
            var regressionOutput = await _regressionOutputRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, regressionOutput);
        }

        [AbpAuthorize(AppPermissions.Pages_RegressionOutputs_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _regressionOutputRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetRegressionOutputsToExcel(GetAllRegressionOutputsForExcelInput input)
        {

            var filteredRegressionOutputs = _regressionOutputRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ParamName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParamNameFilter), e => e.ParamName == input.ParamNameFilter)
                        .WhereIf(input.MinCoeff_EstimateFilter != null, e => e.Coeff_Estimate >= input.MinCoeff_EstimateFilter)
                        .WhereIf(input.MaxCoeff_EstimateFilter != null, e => e.Coeff_Estimate <= input.MaxCoeff_EstimateFilter)
                        .WhereIf(input.MinStd_ErrorFilter != null, e => e.Std_Error >= input.MinStd_ErrorFilter)
                        .WhereIf(input.MaxStd_ErrorFilter != null, e => e.Std_Error <= input.MaxStd_ErrorFilter)
                        .WhereIf(input.Mint_valueFilter != null, e => e.t_value >= input.Mint_valueFilter)
                        .WhereIf(input.Maxt_valueFilter != null, e => e.t_value <= input.Maxt_valueFilter)
                        .WhereIf(input.Minp_valueFilter != null, e => e.p_value >= input.Minp_valueFilter)
                        .WhereIf(input.Maxp_valueFilter != null, e => e.p_value <= input.Maxp_valueFilter);

            var query = (from o in filteredRegressionOutputs
                         select new GetRegressionOutputForViewDto()
                         {
                             RegressionOutput = new RegressionOutputDto
                             {
                                 ParamName = o.ParamName,
                                 Coeff_Estimate = o.Coeff_Estimate,
                                 Std_Error = o.Std_Error,
                                 t_value = o.t_value,
                                 p_value = o.p_value,
                                 Id = o.Id
                             }
                         });

            var regressionOutputListDtos = await query.ToListAsync();

            return _regressionOutputsExcelExporter.ExportToFile(regressionOutputListDtos);
        }

    }
}