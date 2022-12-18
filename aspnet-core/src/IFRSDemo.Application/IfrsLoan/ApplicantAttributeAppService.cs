using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public class ApplicantAttributeAppService : IFRSDemoAppServiceBase, IApplicantAttributeAppService
    {
        private readonly IRepository<ApplicantAttribute> _applicantAttributeRepository;

        public ApplicantAttributeAppService(IRepository<ApplicantAttribute> applicantAttributeRepository)
        {
            _applicantAttributeRepository = applicantAttributeRepository;
        }

        public ListResultDto<ApplicantAttributeListDto> GetApplicantAttribute(GetApplicantAttributeInput input)
        {
            var applicantAttributes = _applicantAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Applicant_With_Accno.Contains(input.Filter)
               )
               .OrderBy(p => p.Applicant_With_Accno)
               // .ThenBy(p => p.Name)
               .ToList();

            return new ListResultDto<ApplicantAttributeListDto>(ObjectMapper.Map<List<ApplicantAttributeListDto>>(applicantAttributes));

        }

    }
}
