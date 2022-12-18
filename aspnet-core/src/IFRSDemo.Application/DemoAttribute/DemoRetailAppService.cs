using Abp.Domain.Repositories;
using IFRSDemo.DemoAttribute.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Authorization;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Domain.Uow;

namespace IFRSDemo.DemoAttribute
{
    [AbpAuthorize(AppPermissions.Pages_DemoRetail)]
    public class DemoRetailAppService : IFRSDemoAppServiceBase, IDemoRetailAppService
    {
        private readonly IRepository<DemoRetailAttrItem> _itemRepo;
        private readonly IRepository<SubRetailAttrItem> _subItemRepo;
        private readonly IDemoRetailRepository _demoRepo;
        private readonly IRepository<RetailCustomer> _customerRepo;
        private readonly IRepository<RetailScore> _retailRepo;
        private readonly IRepository<DemoRetailCutOff> _cutOffRepo;
        private readonly IRepository<RetailCustomerDetail> _customerDetailRepo;

        public DemoRetailAppService(IRepository<DemoRetailAttrItem> itemRepo, IRepository<SubRetailAttrItem> subItemRepo,
                                    IDemoRetailRepository demoRepo, IRepository<RetailCustomer> customerRepo, IRepository<RetailScore> retailRepo,
                                    IRepository<DemoRetailCutOff> cutOffRepo, IRepository<RetailCustomerDetail> customerDetailRepo)
        {
            _itemRepo = itemRepo;
            _subItemRepo = subItemRepo;
            _demoRepo = demoRepo;
            _customerRepo = customerRepo;
            _retailRepo = retailRepo;
            _cutOffRepo = cutOffRepo;
            _customerDetailRepo = customerDetailRepo;
        }

        public async Task CreateDemoRetailAttrItem(CreateDemoRetailAttrDto input)
        {
            var output = ObjectMapper.Map<DemoRetailAttrItem>(input);
            await _itemRepo.InsertAsync(output);
        }

        [AbpAuthorize(AppPermissions.Pages_GetDemoRetailAttrItem)]
        public List<DemoRetailAttrItemDto> GetDemoRetailAttrItem()
        {
            var result = (from o in _itemRepo.GetAll()
                    select new DemoRetailAttrItemDto()
                    {
                        Attribute = o.Attribute,
                        Position = o.Position,
                        Active = o.Active,
                        Id = o.Id
                    }).ToList();
            return result;
        }

        public IEnumerable<DemoRetailAttrItemDto> GetDemoRetailAttrItemById(string searchParam)
        {
            return (from o in _itemRepo.GetAll().Where(x => x.Attribute.Contains(searchParam))
                    select new DemoRetailAttrItemDto()
                    {
                        Attribute = o.Attribute,
                        Position = o.Position,
                        Active = o.Active,
                        Id = o.Id
                    }).ToList();
        }
        public IEnumerable<Object> GetApprovedSubRetailAttr(string AttributeParam)
        {
            string ApprovedDetail = "Approved";
            return (from o in _subItemRepo.GetAll().Where(x => x.AttributeId.Contains(AttributeParam) && x.Status == ApprovedDetail)
                    select new
                    {
                        Attribute = o.AttributeId,
                        SubAttribute = o.SubAttribute,
                        Value = o.Value,
                        Staus = o.Status,
                        Id = o.Id
                    }).ToList();
        }
        public async Task<GetDemoRetailAttrForEditOutput> GetDemoRetailAttrEdit(GetDemoRetailAttrForEditInput input)
        {
            var item = await _itemRepo.GetAsync(input.Id);
            return ObjectMapper.Map<GetDemoRetailAttrForEditOutput>(item);
        }
        public async Task EditDemoRetailAttr(EditDemoRetailAttrInput input)
        {
            var item = await _itemRepo.GetAsync(input.Id);
            item.Attribute = input.Attribute;
            item.Position = input.Position;
            item.Active = input.Active;
            await _itemRepo.UpdateAsync(item);
        }
        public async Task DeleteDemoRetailAttr(EntityDto input)
        {
            await _itemRepo.DeleteAsync(input.Id);
        }
        public IEnumerable<string> DistinctAttribute()
        {
            return _itemRepo.GetAll().Select(x => x.Attribute).Distinct().ToList();
        }

        [AbpAuthorize(AppPermissions.Pages_CreateSubRetailAttrItem)]
        public ApiResponsesDto CreateSubRetailAttrItem(CreateSubRetailAttrItemDto input)
        {
            input.Status = "Pending";
            var existRecord = _subItemRepo.GetAll().Where(t => t.AttributeId == input.AttributeId && t.SubAttribute == input.SubAttribute).FirstOrDefault();
            if (existRecord != null)
            {
                return new ApiResponsesDto
                {
                    Status = 203,
                    Message = $"Detail with attribute  '{input.AttributeId}'  together with subattribute '{input.SubAttribute}' exists"
                };
            }
            else
            {
                var output = ObjectMapper.Map<SubRetailAttrItem>(input);
                _subItemRepo.InsertAsync(output);
                return new ApiResponsesDto
                {
                    Status = 200,
                    Message = "Saved Successfully"
                };
            }
        }
        public IEnumerable<Object> GetSubRetailAttrItem()
        {
            var result = (from o in _subItemRepo.GetAll()
                          select new
                          {
                              Attribute = o.AttributeId,
                              SubAttribute = o.SubAttribute,
                              Value = o.Value,
                              Status = o.Status,
                              Reason = o.Reason,
                              Id = o.Id
                          });
            return result.ToArray();
        }

        [AbpAuthorize(AppPermissions.Pages_GetSubRetailAttrItemEdit)]
        public async Task<GetSubRetailAttrItemForEditOutput> GetSubRetailAttrItemEdit(GetSubRetailAttrItemForEditInput input)
        {
            var item = await _subItemRepo.GetAsync(input.Id);
            return ObjectMapper.Map<GetSubRetailAttrItemForEditOutput>(item);
        }
        public async Task EditSubRetailAttrItem(EditSubRetailAttrItemInput input)
        {
            var item = await _subItemRepo.GetAsync(input.Id);
            item.AttributeId = input.AttributeId;
            item.SubAttribute = input.SubAttribute;
            item.Value = input.Value;
            item.Status = input.Status;
            item.Reason = input.Reason;
            await _subItemRepo.UpdateAsync(item);
        }

        [AbpAuthorize(AppPermissions.Pages_ApproveAttr)]
        public void ApproveAttribute(int param1, string param2)
        {
            _demoRepo.ApproveAttribute(param1, param2);
        }
        [AbpAuthorize(AppPermissions.Pages_DeclineAttr)]
        public void DeclineAttribute(int param1, string param2)
        {
            _demoRepo.DeclineAttribute(param1, param2);
        }

        [AbpAuthorize(AppPermissions.Pages_InsertNewCustomerScore)]
        public ApiResponsesDto InsertNewCustomerScore(string param1, string param2, string param3, string param4, double param5)
        {
            bool isExist = _customerRepo.GetAll().Where(t => t.BVN == param4).Any();
            if (isExist)
            {
                return new ApiResponsesDto { Status = 203, Message = $"Customer  with BVN '{param4}' already exist" };
            }
            bool res = _demoRepo.InsertNewCustomerScore(param1, param2, param3, param4, param5);
            if (res)
            {
                return new ApiResponsesDto { Status = 200, Message = $"Score computed succesfully" };
            }
            return new ApiResponsesDto();
        }
        public ApiResponsesDto AddExistingCustomerScore(CreateRetailScoreDto input)
        {
            //bool isExist = _retailRepo.GetAll().Where(t => t.NameId == input.NameId).Any();
            //if (isExist)
            //{
            //    return new ApiResponseDto { Status = 203, Message = $"Customer already exist" };
            //}
            input.ApprovalStatus = $"Pending";
            var item = ObjectMapper.Map<RetailScore>(input);
            _retailRepo.InsertAsync(item);
            return new ApiResponsesDto { Status = 200, Message = $"Score computed succesfully" };
        }

        [AbpAuthorize(AppPermissions.Pages_GetDetailScores)]
        public IEnumerable<Object> GetDetailScores()
        {
            var result = (from a in _retailRepo.GetAll()
                          join b in _customerRepo.GetAll() on a.NameId equals b.Id
                          select new
                          {
                              FullName = b.FirstName + " " + b.LastName,
                              BVN = b.BVN,
                              AccountNo = b.AccountNo,
                              Score = a.Score,
                              Status = a.ApprovalStatus,
                              Id = a.Id
                          }).ToList();
            return result;
        }

        public IEnumerable<Object> GetExistingCustomer()
        {
            var result = from b in _customerRepo.GetAll()
                         select new
                         {
                             FirstName = b.FirstName,
                             LastName = b.LastName,
                             BVN = b.BVN,
                             AccountNo = b.AccountNo,
                             Id = b.Id
                         };
            return result.ToList();
        }
        public void ReverseAttribute(int param1)
        {
            _demoRepo.ReverseAttribute(param1);
        }

        [AbpAuthorize(AppPermissions.Pages_GetRetailScoreItemEdit)]
        public async Task<GetRetailScoreForEditOutput> GetRetailScoreItemEdit(GetRetailScoreForEditInput input)
        {
            var item = await _retailRepo.GetAsync(input.Id);
            return ObjectMapper.Map<GetRetailScoreForEditOutput>(item);
        }
        public async Task EditRetailScore(EditRetailScoreInput input)
        {
            var item = await _retailRepo.GetAsync(input.Id);
            item.NameId = input.NameId;
            item.Score = input.Score;
            await _retailRepo.UpdateAsync(item);
        }


        [AbpAuthorize(AppPermissions.Pages_AddCutOff)]
        [UnitOfWork]
        public bool AddCutOff(DemoRetailCutOffDto input)
        {
            bool isSuccess;
            var context = _cutOffRepo.GetDbContext();
            var removeCuttOff = _cutOffRepo.GetAll().ToList();
            foreach (DemoRetailCutOff cut in removeCuttOff)
            {
                context.Remove(cut);
            }
            var item = ObjectMapper.Map<DemoRetailCutOff>(input);
            //await _cutOffRepo.InsertAsync(item);
            context.Add(item);
            isSuccess = context.SaveChanges() > 0;
            return isSuccess;
        }
        public IEnumerable<Object> GetCutOff()
        {
            int param = 1;
            var res = from a in _cutOffRepo.GetAll()
                      select new
                      {
                          CutOff = a.CuttOff,
                          Id = a.Id
                      };
            return res.OrderByDescending(x => x.Id).Take(param).ToArray();
        }

        public async Task<RetailCustomerDetailForEditOutput> GetRetailCustomerDetailEdit(GetRetailCustomerDetailEditInput input)
        {
            var item = await _customerDetailRepo.GetAsync(input.Id);
            var res = ObjectMapper.Map<RetailCustomerDetailForEditOutput>(item);
            return res;
        }

        public async Task EditRetailCustomerDetail(RetailCustomerDetailInput input)
        {
            var item = await _customerDetailRepo.GetAsync(input.Id);
            item.FirstName = input.FirstName;
            item.LastName = input.LastName;
            item.AccountNo = input.AccountNo;
            item.BVN = input.BVN;
            await _customerDetailRepo.UpdateAsync(item);
        }
        public IEnumerable<Object> GetRetailCustomerDetail()
        {
            return (from o in _customerDetailRepo.GetAll()
                    select new
                    {
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        AccountNo = o.AccountNo,
                        BVN = o.BVN,
                        Id = o.Id
                    }).ToArray();
        }
        public async Task UpdateStatus(int id, string param)
        {
            var data = await _retailRepo.GetAsync(id);
            data.ApprovalStatus = param;
            await _retailRepo.UpdateAsync(data);
        }
       
    }
}
