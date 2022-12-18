using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using IFRSDemo.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.Runtime.Session;
using System.Data;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoanHistogram)]
    public class HistogramAppService : IFRSDemoAppServiceBase, IHistogramAppService
    {
        private readonly IRepository<Histogram> _histogramRepository;
        private readonly IRepository<Component, int> _componentRepository;
        private readonly IHistogramRepository _histogramSppRepository;
        private readonly IAbpSession _abp;


        public HistogramAppService(IRepository<Histogram> histogramRepository, IRepository<Component, int> componentRepository, IAbpSession abp, IHistogramRepository histogramSppRepository)
        {
            _histogramRepository = histogramRepository;
            _componentRepository = componentRepository;
            _abp = abp;
            _histogramSppRepository = histogramSppRepository;

        }

        public string[] GetDistinctTop1Feature()
        {
            return _histogramSppRepository.GetDistinctTop1Feature();
        }

        public string[] GetDistinctFeatures()
        {
            return _histogramSppRepository.GetDistinctFeatures();
        }

        public string[] GetCombinations()
        {
            return _histogramSppRepository.GetCombinations();
        }

        public void UpdateRecords(string optVal)
        {
            _histogramSppRepository.UpdateRecords(optVal);
        }


        //public string GetHistogramData(string ftname)
        //{
        //    // _histogramAppRepository.GetHistogram();
        //    // return _histogramSppRepository.GetHistogramData(ftname);
        //    //var item = new PortfolioModel();
        //    return _histogramSppRepository.GetAllHistogramChart(ftname);

        //}
        //public string GetAllHistogramChart(string ftname)
        //{
        //    return _histogramSppRepository.GetAllHistogramChart(ftname);
        //}
        public ListResultDto<HistogramListDto> GetHistogram(GetHistogramInput input)
        {
            var histograms = _histogramRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.featurename.Contains(input.Filter) ||
                           p.lowerBound.Contains(input.Filter) ||
                           p.upperBound.ToString().Contains(input.Filter) ||
                           p.count.ToString().Contains(input.Filter) ||
                           p.percent.ToString().Contains(input.Filter)

               )
               .OrderBy(p => p.featurename)
               .ThenBy(p => p.lowerBound)
               .ToList();

            return new ListResultDto<HistogramListDto>(ObjectMapper.Map<List<HistogramListDto>>(histograms));

        }
        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_CreateHistogram)]
        public async Task CreateHistogram(CreateHistogramInput input)
        {
            input.TenantId = _abp.GetTenantId();
            var histogram = ObjectMapper.Map<Histogram>(input);
            await _histogramRepository.InsertAsync(histogram);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_DeleteHistogram)]
        public async Task DeleteHistogram(EntityDto input)
        {
            await _histogramRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditHistogram)]
        public async Task<GetHistogramForEditOutput> GetHistogramForEdit(GetHistogramForEditInput input)
        {
            var histogram = await _histogramRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetHistogramForEditOutput>(histogram);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditHistogram)]
        public async Task EditHistogram(EditHistogramInput input)
        {
            var histogram = await _histogramRepository.GetAsync(input.Id);
            histogram.featurename = input.featurename;
            histogram.lowerBound = input.lowerBound;
            histogram.upperBound = input.upperBound;
            histogram.count = input.count;
            histogram.percent = input.percent;
            await _histogramRepository.UpdateAsync(histogram);
        }

        public async Task<List<ComponentTableDto>> GetAllComponentForTableDropdown()
        {
            return await _componentRepository.GetAll()
                .Select(itemUnit => new ComponentTableDto
                {
                    Id = itemUnit.Id,
                    Name = itemUnit == null || itemUnit.Name == null ? "" : itemUnit.Name.ToString()
                }).ToListAsync();

        }

        public void RunDistStat()
        {
            _histogramSppRepository.RunDistStat();
        }
    }
}

