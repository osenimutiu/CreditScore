using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CreateOrEditQualitativeSetupDto : EntityDto<int?>
    {

        public string Section { get; set; }

        public string SubHeading { get; set; }

        public string Qualitative { get; set; }

        public int Value { get; set; }

        public bool Status { get; set; }

    }
}