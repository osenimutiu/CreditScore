using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetSubHeadingSetupForEditOutput
    {
        public CreateOrEditSubHeadingSetupDto SubHeadingSetup { get; set; }

        public string SectionSetupSection { get; set; }

    }
}