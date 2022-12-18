using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
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
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;


namespace IFRSDemo.IfrsLoan
{
   [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoanScoringInputData)]
    public class ScoringInputDataAppService : IFRSDemoAppServiceBase, IScoringInputDataAppService
    {
        private readonly IRepository<ScoringInputData> _scoringInputDataRepository;
        private readonly ScoringInputDataEngineManager _scoringInputDataEngine;
        private readonly IAbpSession _abps;
        private readonly IScoringInputDataRepository _scoreRepository;
       
        public ScoringInputDataAppService(IRepository<ScoringInputData> scoringInputDataRepository, ScoringInputDataEngineManager scoringInputDataEngine, IAbpSession abps, IScoringInputDataRepository scoreRepository, IAbpSession abp)
        {
            _scoringInputDataRepository = scoringInputDataRepository;
            _scoringInputDataEngine = scoringInputDataEngine;
            _abps = abps;
            _scoreRepository = scoreRepository;
        }

        public async Task<PagedResultDto<ScoringInputDataListDto>> GetScoringInputData(GetScoringInputDataInput input)
        {
            var filteredInventories = _scoringInputDataRepository.GetAll()
                       
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.TrainingSample.ToString().Contains(input.Filter) ||
                        e.UniqueID.Contains(input.Filter) ||
                        e.Age.ToString().Contains(input.Filter) ||
                        e.ReturnonAssets.ToString().Contains(input.Filter) ||
                        e.Location.Contains(input.Filter) ||
                        e.Residentstatus.Contains(input.Filter) ||
                        e.TimeatJob.ToString().Contains(input.Filter) ||
                        e.Timeatresidence.ToString().Contains(input.Filter) ||
                        e.Product.Contains(input.Filter) ||
                        e.Sector.Contains(input.Filter) ||
                        e.Subsector.Contains(input.Filter) ||
                        e.CurrentAccountStatus.Contains(input.Filter) ||
                        e.Totalassets.ToString().Contains(input.Filter) ||
                        e.Rent.ToString().Contains(input.Filter) ||
                        e.RenttoIncome.ToString().Contains(input.Filter) ||
                        e.TimeatBank.ToString().Contains(input.Filter) ||
                        e.Numberofproducts.ToString().Contains(input.Filter) ||
                        e.Paymentperformance.Contains(input.Filter) ||
                        e.Previousclaims.ToString().Contains(input.Filter) ||
                        e.GoodBad.ToString().Contains(input.Filter) ||
                        e.Dateopened.Contains(input.Filter) ||
                        e.Income.ToString().Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UniqueIDFilter), e => e.UniqueID == input.UniqueIDFilter);
                        
            var pagedAndFilteredInventories = filteredInventories
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);
            var inventories = from o in pagedAndFilteredInventories
                              
                              select new ScoringInputDataListDto()
                              {
                                  
                                      TrainingSample = o.TrainingSample,
                                      UniqueID = o.UniqueID,
                                      Age = o.Age,
                                      ReturnonAssets = o.ReturnonAssets,
                                      Location = o.Location,
                                      Rent = o.Rent,
                                      RenttoIncome = o.RenttoIncome,
                                      Previousclaims = o.Previousclaims,
                                      Paymentperformance = o.Paymentperformance,
                                      Income = o.Income,
                                      Sector = o.Sector,
                                      Residentstatus = o.Residentstatus,
                                      Subsector = o.Subsector,
                                      TimeatBank = o.TimeatBank,
                                      Numberofproducts = o.Numberofproducts,
                                      Product = o.Product,
                                      TimeatJob = o.TimeatJob,
                                      CurrentAccountStatus = o.CurrentAccountStatus,
                                      Dateopened = o.Dateopened,
                                      Totalassets = o.Totalassets,
                                      Timeatresidence = o.Timeatresidence,
                                      Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();
           

            return new PagedResultDto<ScoringInputDataListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }




        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_DeleteScoringInputData)]
        public async Task DeleteScoringInputData(EntityDto input)
        {
            await _scoringInputDataRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringInputData)]
        public async Task<GetScoringInputDataForEditOutput> GetScoringInputDataForEdit(GetScoringInputDataForEditInput input)
        {
            var scoringInputData = await _scoringInputDataRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetScoringInputDataForEditOutput>(scoringInputData);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringInputData)]
        public async Task EditScoringInputData(EditScoringInputDataInput input)
        {
            var scoringInputData = await _scoringInputDataRepository.GetAsync(input.Id);
            scoringInputData.TrainingSample = input.TrainingSample;
            scoringInputData.UniqueID = input.UniqueID;
            scoringInputData.Age = input.Age;
            scoringInputData.Income = input.Income;
            scoringInputData.ReturnonAssets = input.ReturnonAssets;
            scoringInputData.Location = input.Location;
            scoringInputData.Residentstatus = input.Residentstatus;
            scoringInputData.TimeatJob = input.TimeatJob;
            scoringInputData.Timeatresidence = input.Timeatresidence;
            scoringInputData.Product = input.Product;
            scoringInputData.Sector = input.Sector;
            scoringInputData.Subsector = input.Subsector;
            scoringInputData.CurrentAccountStatus = input.CurrentAccountStatus;
            scoringInputData.Totalassets = input.Totalassets;
            scoringInputData.Rent = input.Rent;
            scoringInputData.RenttoIncome = input.RenttoIncome;
            scoringInputData.TimeatBank = input.TimeatBank;
            scoringInputData.Numberofproducts = input.Numberofproducts;
            scoringInputData.Paymentperformance = input.Paymentperformance;
            scoringInputData.Previousclaims = input.Previousclaims;
            scoringInputData.GoodBad = input.GoodBad;
            scoringInputData.Dateopened = input.Dateopened;
            await _scoringInputDataRepository.UpdateAsync(scoringInputData);
        }

        public async Task<PostResultDto> CreateScoringInputData(List<CreateScoringInputDataDto> input)
        {
            
            var itemvalue = _scoringInputDataEngine.GetListScoringInputData().Result;
            if (itemvalue.Count() > 0)
            {
                foreach (var item in itemvalue)
                {

                    _scoringInputDataEngine.UpdateScoringInputDataAsync(item);
                }

            }
            var result = new PostResultDto { ResponseCode = "00", ResponseDetails = "Successful" };

            var newList = new List<CreateScoringInputDataDto>();
            newList = input;
            if (input.Count() == 0)
            {
                result.ResponseCode = "99";
                result.ResponseDetails = "No valid record";
            }
            else
            {
                foreach (var item in input.ToList())
                {
                    List<ScoringInputData> acctList = new List<ScoringInputData>();

                    var account = new ScoringInputData();
                    account.TenantId = _abps.GetTenantId();
                    account.TrainingSample = item.TrainingSample;
                    account.UniqueID = item.UniqueID;
                    account.Age = item.Age;
                    account.Income = item.Income;
                    account.ReturnonAssets = item.ReturnonAssets;
                    account.Location = item.Location;
                    account.Residentstatus = item.Residentstatus;
                    account.TimeatJob = item.TimeatJob;
                    account.Timeatresidence = item.Timeatresidence;
                    account.Product = item.Product;
                    account.Sector = item.Sector;
                    account.Subsector = item.Subsector;
                    account.CurrentAccountStatus = item.CurrentAccountStatus;
                    account.Totalassets = item.Totalassets;
                    account.Rent = item.Rent;
                    account.RenttoIncome = item.RenttoIncome;
                    account.TimeatBank = item.TimeatBank;
                    account.Numberofproducts = item.Numberofproducts;
                    account.Previousclaims = item.Previousclaims;
                    account.GoodBad = item.GoodBad;
                    account.Paymentperformance = item.Paymentperformance;
                    account.Dateopened = item.Dateopened;
                    acctList.Add(account);

                    _scoringInputDataEngine.CreateScoringInputData(acctList);

                }


            }
            return result;
        }

        public void ComputeWholeScore()
        {
            
            _scoreRepository.ComputeBulkScore();
        }
    }
}
