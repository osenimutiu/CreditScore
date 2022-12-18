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

namespace IFRSDemo.IfrsLoan
{
   public class OperationAppService : IFRSDemoAppServiceBase, IOperationAppService
    {
        private readonly IRepository<Operation> _operationRepository;
        public OperationAppService(IRepository<Operation> operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public ListResultDto<OperationListDto> GetOperation(GetOperationInput input)
        {
            var operations = _operationRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.OperationName.Contains(input.Filter) 

               )
               //.OrderBy(p => p.featurename)
               //.ThenBy(p => p.lowerBound)
               .ToList();

            return new ListResultDto<OperationListDto>(ObjectMapper.Map<List<OperationListDto>>(operations));

        }
    }
}
