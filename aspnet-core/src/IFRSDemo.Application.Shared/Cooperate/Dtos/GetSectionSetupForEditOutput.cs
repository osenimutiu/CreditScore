using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetSectionSetupForEditOutput
    {
        public CreateOrEditSectionSetupDto SectionSetup { get; set; }

    }
}