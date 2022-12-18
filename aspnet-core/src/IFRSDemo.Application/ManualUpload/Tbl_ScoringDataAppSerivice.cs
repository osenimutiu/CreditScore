using Abp.Domain.Repositories;
using IFRSDemo.ManualUpload.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using IFRSDemo.Authorization;
using Abp.Authorization;

namespace IFRSDemo.ManualUpload
{
    [AbpAuthorize(AppPermissions.Pages_TblScoring)]
    public class Tbl_ScoringDataAppSerivice : IFRSDemoAppServiceBase, ITbl_ScoringDataAppService
    {
        private readonly IRepository<Tbl_ScoringData> _inputRepo;
        public Tbl_ScoringDataAppSerivice(IRepository<Tbl_ScoringData> inputRepo)
        {
            _inputRepo = inputRepo;
        }
        [AbpAuthorize(AppPermissions.Pages_TblScoringGetInputData)]
        public async Task<PagedResultDto<Tbl_ScoringDataDto>> GetInputData(GetInputDataInput input)
        {
            var filteredInventories = _inputRepo.GetAll()
                      .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                      e.Unique_ID.Contains(input.Filter))
                      .WhereIf(!string.IsNullOrWhiteSpace(input.UniqueIDFilter), e => e.Unique_ID == input.UniqueIDFilter);
            var pagedAndFilteredInventories = filteredInventories
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);
            var inventories = from e in pagedAndFilteredInventories
                              select new Tbl_ScoringDataDto()
                              {
                                  Unique_ID = e.Unique_ID,
                                  TrainingSample = e.TrainingSample,
                                  Date_opened = e.Date_opened,
                                  Age = e.Age,
                                  Income = e.Income,
                                  Location = e.Location,
                                  Resident_status = e.Resident_status,
                                  Time_at_Job = e.Time_at_Job,
                                  Time_at_residence = e.Time_at_residence,
                                  Product = e.Product,
                                  Current_Account_Status = e.Current_Account_Status,
                                  Total_assets = e.Total_assets,
                                  Rent = e.Rent,
                                  Rent_to_Income = e.Rent_to_Income,
                                  Return_on_Assets = e.Return_on_Assets,
                                  Time_at_Bank = e.Time_at_Bank,
                                  Number_of_products = e.Number_of_products,
                                  Payment_performance = e.Payment_performance,
                                  Previous_claims = e.Previous_claims,
                                  Good_Bad = e.Good_Bad,
                                  Id = e.Id
                              };
            var totalCount = await filteredInventories.CountAsync();
            return new PagedResultDto<Tbl_ScoringDataDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }
        [AbpAuthorize(AppPermissions.Pages_TblScoringInsertScoring)]
        public async Task InsertScoring(List<Tbl_ScoringData> data)
        {
            if (data == null)
            {
                data = new List<Tbl_ScoringData>();
            }
            foreach (Tbl_ScoringData cust in data)
            {
                await _inputRepo.InsertAsync(cust);
            }
        }
       public List<Tbl_ScoringDataDto> GetInputDataForCount()
        {
            var inventories = from e in _inputRepo.GetAll()
                              select new Tbl_ScoringDataDto()
                              {
                                  Unique_ID = e.Unique_ID,
                                  TrainingSample = e.TrainingSample,
                                  Date_opened = e.Date_opened,
                                  Age = e.Age,
                                  Income = e.Income,
                                  Location = e.Location,
                                  Resident_status = e.Resident_status,
                                  Time_at_Job = e.Time_at_Job,
                                  Time_at_residence = e.Time_at_residence,
                                  Product = e.Product,
                                  Current_Account_Status = e.Current_Account_Status,
                                  Total_assets = e.Total_assets,
                                  Rent = e.Rent,
                                  Rent_to_Income = e.Rent_to_Income,
                                  Return_on_Assets = e.Return_on_Assets,
                                  Time_at_Bank = e.Time_at_Bank,
                                  Number_of_products = e.Number_of_products,
                                  Payment_performance = e.Payment_performance,
                                  Previous_claims = e.Previous_claims,
                                  Good_Bad = e.Good_Bad,
                                  Id = e.Id
                              };
            return inventories.ToList();
        }
    }
}
