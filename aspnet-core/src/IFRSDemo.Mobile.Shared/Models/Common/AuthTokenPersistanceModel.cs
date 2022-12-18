using System;
using Abp.AutoMapper;
using IFRSDemo.Sessions.Dto;

namespace IFRSDemo.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}