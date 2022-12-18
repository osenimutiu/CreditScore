using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Runtime.Session;
using System.Text;
using System.Threading.Tasks;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Authorization;
using IFRSDemo.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_ApplicationScoring)]
    public class ApplicationScoringAppService : IFRSDemoAppServiceBase, IApplicationScoringAppService
    {

        private readonly IRepository<ApplicationScoring> _applicationScoringRepository;
        private readonly IRepository<AgeAttribute, int> _ageAttributeRepository;
        private readonly IRepository<ProductTypeAttribute, int> _productTypeAttributeRepository;
        private readonly IRepository<IncomeAttribute, int> _incomeAttributeRepository;
        private readonly IRepository<LocationAttribute, int> _locationAttributeRepository;
        private readonly IRepository<RentAttribute, int> _rentAttributeRepository;
        private readonly IRepository<RenttoIncomeAttribute, int> _renttoIncomeAttributeRepository;
        private readonly IRepository<ReturnonAssetsAttribute, int> _returnonAssetsAttributeRepository;
        private readonly IRepository<SubSectorAttribute, int> _subSectorAttributeRepository;
        private readonly IRepository<AppAttribute, int> _appAttributeRepository;
        private readonly IRepository<ApplicantAttribute, int> _applicantAttributeRepository;
        private readonly IApplicationScoringRepository _scoringRepository;
        private readonly IAbpSession _abp;

        public ApplicationScoringAppService(IRepository<ApplicationScoring> applicationScoringRepository, IRepository<AgeAttribute, int> ageAttributeRepository, IRepository<ProductTypeAttribute, int> productTypeAttributeRepository,
            IRepository<IncomeAttribute, int> incomeAttributeRepository, IRepository<LocationAttribute, int> locationAttributeRepository, IRepository<RentAttribute, int> rentAttributeRepository,
            IRepository<RenttoIncomeAttribute, int> renttoIncomeAttributeRepository, IRepository<ReturnonAssetsAttribute, int> returnonAssetsAttributeRepository, IRepository<SubSectorAttribute, int> subSectorAttributeRepository,
            IApplicationScoringRepository scoringRepository, IRepository<AppAttribute, int> appAttributeRepository, IRepository<ApplicantAttribute, int> applicantAttributeRepository, IAbpSession abp)
        {
            _applicationScoringRepository = applicationScoringRepository;
            _ageAttributeRepository = ageAttributeRepository;
            _productTypeAttributeRepository = productTypeAttributeRepository;
            _incomeAttributeRepository = incomeAttributeRepository;
            _locationAttributeRepository = locationAttributeRepository;
            _rentAttributeRepository = rentAttributeRepository;
            _renttoIncomeAttributeRepository = renttoIncomeAttributeRepository;
            _returnonAssetsAttributeRepository = returnonAssetsAttributeRepository;
            _subSectorAttributeRepository = subSectorAttributeRepository;
            _appAttributeRepository = appAttributeRepository;
            _applicantAttributeRepository = applicantAttributeRepository;
            _scoringRepository = scoringRepository;
            _abp = abp;
        }

        public void ComputeFirstApplicationScore(int param1, int param2, int param3, int param4, int param5, int param6, int param7, string param8, string param9, int param10)
        {
            param10 = _abp.GetTenantId();
             _scoringRepository.ComputeApplicationScore(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
        }

        public void ComputeSecondApplicationScore(string param11, string param9, string custid, int param10)
        {
            param10 = _abp.GetTenantId();
            _scoringRepository.ComputeApplicationScore2(param11, param9, custid, param10);
        }

        public async Task CreateApplicationScoring(CreateApplicationScoringInput input)
        {
            input.TenantId = _abp.GetTenantId();
            var applicationScoring = ObjectMapper.Map<ApplicationScoring>(input);
            await _applicationScoringRepository.InsertAsync(applicationScoring);
        }

         public async Task<PagedResultDto<ApplicationScoringListDto>> GetApplicationScoring(GetApplicationScoringInput input)
        {
            var histograms = _applicationScoringRepository
               .GetAll()
               .Include(e => e.AgeAttributeFK)
                .Include(e => e.IncomeAttributeFK)
                .Include(e => e.ProductTypeAttributeFK)
                .Include(e => e.RentAttributeFK)
                .Include(e => e.RenttoIncomeAttributeFK)
                .Include(e => e.ReturnonAssetsAttributeFK)
                .Include(e => e.LocationAttributeFK)
                .Include(e => e.SubSectorAttributeFK)
                .Include(e => e.AppAttributeFK)
                .Include(e => e.ApplicantAttributeFK)
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Appld.ToString().Contains(input.Filter) ||
                           p.ProductTypeId.ToString().Contains(input.Filter) ||
                           p.LoanRequest.Contains(input.Filter) ||
                           p.Amount.ToString().Contains(input.Filter) ||
                           p.TenorMonth.ToString().Contains(input.Filter) ||
                           p.AgeAttributeId.ToString().Contains(input.Filter) ||
                           p.IncomeAttributeId.ToString().Contains(input.Filter) ||
                           p.LocationAttributeId.ToString().Contains(input.Filter) ||
                           p.RentAttributeId.ToString().Contains(input.Filter) ||
                           p.RenttoIncomeAttributeId.ToString().Contains(input.Filter) ||
                           p.ReturnonAssetsAttributeId.ToString().Contains(input.Filter) ||
                           p.SubSectorAttributeId.ToString().Contains(input.Filter) ||
                           p.Appld.ToString().Contains(input.Filter) ||
                           p.ApplicantId.ToString().Contains(input.Filter) ||
                           p.ExtraParam1.Contains(input.Filter) ||
                           p.ExtraParam2.ToString().Contains(input.Filter))
                               .WhereIf(!string.IsNullOrWhiteSpace(input.ApplicanFilter), e => e.Appld.ToString() == input.ApplicanFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.LoanRequestFilter), e => e.LoanRequest == input.LoanRequestFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.AmountFilter), e => e.Amount.ToString() == input.AmountFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.TenorMonthFilter), e => e.TenorMonth.ToString() == input.TenorMonthFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.ExtraParam1Filter), e => e.ExtraParam1 == input.ExtraParam1Filter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.ExtraParam2Filter), e => e.ExtraParam2.ToString() == input.ExtraParam2Filter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.AgeAttributeFilter), e => e.AgeAttributeFK != null && e.AgeAttributeFK.AgeGroup == input.AgeAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.IncomeAttributeFilter), e => e.IncomeAttributeFK != null && e.IncomeAttributeFK.IncomeRange == input.IncomeAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.ProductTypeAttributeFilter), e => e.ProductTypeAttributeFK != null && e.ProductTypeAttributeFK.ProductType == input.ProductTypeAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.RentAttributeFilter), e => e.RentAttributeFK != null && e.RentAttributeFK.RentGroup == input.RentAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.RenttoIncomeAttributeFilter), e => e.RenttoIncomeAttributeFK != null && e.RenttoIncomeAttributeFK.RentToIncomeGroup == input.RenttoIncomeAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.ReturnonAssetsAttributeFilter), e => e.ReturnonAssetsAttributeFK != null && e.ReturnonAssetsAttributeFK.ReturnonAssets == input.ReturnonAssetsAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.LocationAttributeFilter), e => e.LocationAttributeFK != null && e.LocationAttributeFK.LocationGroup == input.LocationAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.SubSectorAttributeFilter), e => e.SubSectorAttributeFK != null && e.SubSectorAttributeFK.SectorGroup == input.SubSectorAttributeFilter)
                               .WhereIf(!string.IsNullOrWhiteSpace(input.Applicant_With_AccnoFilter), e => e.ApplicantAttributeFK != null && e.ApplicantAttributeFK.Applicant_With_Accno == input.Applicant_With_AccnoFilter);

            var pagedAndFilteredInventories = histograms
            .OrderBy(p => p.Amount)
            .ThenBy(p => p.LoanRequest);
       
            var appScoring = from o in pagedAndFilteredInventories
                              join o1 in _ageAttributeRepository.GetAll() on o.AgeAttributeId equals o1.Id into j2
                              from s2 in j2.DefaultIfEmpty()

                             join o9 in _appAttributeRepository.GetAll() on o.Appld equals o9.Id into j10
                             from s9 in j10.DefaultIfEmpty()

                             join o10 in _applicantAttributeRepository.GetAll() on o.Appld equals o10.Id into j11
                             from s10 in j11.DefaultIfEmpty()

                             join o2 in _productTypeAttributeRepository.GetAll() on o.ProductTypeId equals o2.Id into j3
                              from s3 in j3.DefaultIfEmpty()
                              join o3 in _incomeAttributeRepository.GetAll() on o.IncomeAttributeId equals o3.Id into j4
                              from s4 in j4.DefaultIfEmpty()
                              join o4 in _locationAttributeRepository.GetAll() on o.LocationAttributeId equals o4.Id into j5
                              from s5 in j5.DefaultIfEmpty()
                              join o5 in _rentAttributeRepository.GetAll() on o.RentAttributeId equals o5.Id into j6
                              from s6 in j6.DefaultIfEmpty()
                             join o6 in _renttoIncomeAttributeRepository.GetAll() on o.RenttoIncomeAttributeId equals o6.Id into j7
                              from s7 in j7.DefaultIfEmpty()
                              join o7 in _returnonAssetsAttributeRepository.GetAll() on o.ReturnonAssetsAttributeId equals o7.Id into j8
                              from s8 in j8.DefaultIfEmpty()
                              join o8 in _subSectorAttributeRepository.GetAll() on o.SubSectorAttributeId equals o8.Id



                             into j1
                              from s1 in j1.DefaultIfEmpty()

                              select new ApplicationScoringListDto()
                              {
                                 
                                      Appld = o.Appld,
                                      ApplicantId = o.ApplicantId,
                                      ProductTypeId = o.ProductTypeId,
                                      LoanRequest = o.LoanRequest,
                                      Amount = o.Amount,
                                      TenorMonth = o.TenorMonth,
                                      AgeAttributeId = o.AgeAttributeId,
                                      IncomeAttributeId = o.IncomeAttributeId,
                                      LocationAttributeId = o.LocationAttributeId,
                                      RentAttributeId = o.RentAttributeId,
                                      RenttoIncomeAttributeId = o.RenttoIncomeAttributeId,
                                      ReturnonAssetsAttributeId = o.ReturnonAssetsAttributeId,
                                      SubSectorAttributeId = o.SubSectorAttributeId,
                                      ExtraParam1 = o.ExtraParam1,
                                      ExtraParam2 = o.ExtraParam2,
                                      Id = o.Id,
                                 
                                  ApplicationScoringTypeAgeGroup = s2 == null || s2.AgeGroup == null ? "" : s2.AgeGroup.ToString(),
                                  ApplicationScoringProductType = s3 == null || s3.ProductType == null ? "" : s3.ProductType.ToString(),
                                  ApplicationScoringTypeIncomeRange = s4 == null || s4.IncomeRange == null ? "" : s4.IncomeRange.ToString(),
                                  ApplicationScoringTypeRentGroup = s6 == null || s6.RentGroup == null ? "" : s6.RentGroup.ToString(),
                                  ApplicationScoringTypeRentToIncomeGroup = s7 == null || s7.RentToIncomeGroup == null ? "" : s7.RentToIncomeGroup.ToString(),
                                  ApplicationScoringTypeReturnonAssets = s8 == null || s8.ReturnonAssets == null ? "" : s8.ReturnonAssets.ToString(),
                                  ApplicationScoringTypeSectorGroup = s1 == null || s1.SectorGroup == null ? "" : s1.SectorGroup.ToString(),
                                  ApplicationScoringTypeLocationGroup = s5 == null || s5.LocationGroup == null ? "" : s5.LocationGroup.ToString(),
                                  ApplicationScoringTypeApp = s9 == null || s9.ApplicanType == null ? "" : s9.ApplicanType.ToString()
                              };
            var totalCount = await histograms.CountAsync();

            return new PagedResultDto<ApplicationScoringListDto>(
                totalCount,
                await appScoring.ToListAsync()
            );
        }

    }
}
