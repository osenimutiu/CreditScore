using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CreateOrEditSetupSubHeadingDto : EntityDto<int?>
    {

        public string SubHeading { get; set; }

        public int SectionSetupId { get; set; }

    }
}