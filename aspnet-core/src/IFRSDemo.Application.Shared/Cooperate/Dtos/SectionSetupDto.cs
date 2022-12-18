using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class SectionSetupDto : EntityDto
    {
        public string Section { get; set; }

        public int Position { get; set; }

        public bool Active { get; set; }

    }
}