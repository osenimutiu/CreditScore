using System.Collections.Generic;
using Abp.Application.Services.Dto;
using IFRSDemo.Editions.Dto;

namespace IFRSDemo.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}