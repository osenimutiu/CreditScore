using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using IFRSDemo.Authorization;
using IFRSDemo.IfrsLoan;
using IFRSDemo.SetUp.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SetUp
{
    [AbpAuthorize(AppPermissions.Pages_SetUp)]
    public class SetUpItemAppService : IFRSDemoAppServiceBase, ISetUpItemAppService
    {
        private readonly IRepository<SetUpItem> _setRepository;
        private readonly IRepository<Method> _methodRepository;
        private readonly IHistogramRepository _histohram;
        private readonly IRepository<SplittingMethod> _splittingRepository;
        //private readonly IRepository<AgeRange> _ageRepo;
        public SetUpItemAppService(IRepository<SetUpItem> setRepository, IRepository<Method> methodRepository, IHistogramRepository histohram, IRepository<SplittingMethod> splittingRepository
            )
        {
            _setRepository = setRepository;
            _methodRepository = methodRepository;
            _histohram = histohram;
            _splittingRepository = splittingRepository;
            //_ageRepo = ageRepo;
        }
        [AbpAuthorize(AppPermissions.Pages_CreateSetUp)]
        public async Task CreateSetUp(CreateSetUpItemDto input)
        {
            _histohram.MaintainSingleRecord();
            var setUp = ObjectMapper.Map<SetUpItem>(input);
            await _setRepository.InsertAsync(setUp);
        }

        //public AgeRangeDto[] GetAgeRangeList()
        //{
        //    var age = (from o in _ageRepo.GetAll()
        //               select new AgeRangeDto()
        //               {
        //                   Age = o.Age,
        //                   Id = o.Id
        //               }).ToArray();
        //    return age;
        //}
        public ListResultDto<MethodListDto> GetSetUp()
        {
            var result = _methodRepository.GetAll().ToList();
            return new ListResultDto<MethodListDto>(ObjectMapper.Map<List<MethodListDto>>(result));
        }
        [AbpAuthorize(AppPermissions.Pages_GetSetUpList)]
        public ListResultDto<SetUpItemListDto> GetSetUpList()
        {
            var joinTable = (from objSetUp in _setRepository.GetAll()
                             join objMethod in _methodRepository.GetAll()
                             on objSetUp.MethodId equals objMethod.Id
                             join split in _splittingRepository.GetAll()
                            on objSetUp.SplittingMethodId equals split.Id
                             select new SetUpItemListDto()
                             {
                                 Email = objSetUp.Email,
                                 Training = objSetUp.Training,
                                 Test = objSetUp.Test,
                                 Method = objMethod.MethodName,
                                 SplittingMethod = split.SplittingName,
                                 MaxAge = objSetUp.MaxAge,
                                 MinAge = objSetUp.MinAge,
                                 Id = objSetUp.Id
                             }).ToList();
           
            return new ListResultDto<SetUpItemListDto>(ObjectMapper.Map<List<SetUpItemListDto>>(joinTable));
        }

        public ListResultDto<SplittingMethodListDto> GetSplittingMethod()
        {
            var splitting = (from obj in _splittingRepository.GetAll()
                             select new SplittingMethodListDto()
                             {
                                 MethodName = obj.SplittingName,
                                 Id = obj.Id
                             });
            return new ListResultDto<SplittingMethodListDto>(ObjectMapper.Map<List<SplittingMethodListDto>>(splitting));
        }


        [AbpAuthorize(AppPermissions.Pages_GetSetUpItemEdit)]
        public async Task<GetSetUpItemForEditOutput> GetSetUpItemEdit(GetSetUpItemForEditInput input)
        {
            var setUpItem = await _setRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetSetUpItemForEditOutput>(setUpItem);
        }
        public async Task EditSetUpItem(EditSetUpItemInput input)
        {
            var setUpItem = await _setRepository.GetAsync(input.Id);
            setUpItem.Training = input.Training;
            setUpItem.Test = input.Test;
            setUpItem.Email = input.Email;
            setUpItem.MethodId = input.MethodId;
            setUpItem.SplittingMethodId = input.SplittingMethodId;
            setUpItem.MinAge = input.MinAge;
            setUpItem.MaxAge = input.MaxAge;
            setUpItem.MethodId = input.MethodId;
            await _setRepository.UpdateAsync(setUpItem);
        }
    }
}
