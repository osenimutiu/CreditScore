using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class SubSectorSetupDto : EntityDto
    {
        public string Section { get; set; }

        public string SubHeading { get; set; }

    }
}