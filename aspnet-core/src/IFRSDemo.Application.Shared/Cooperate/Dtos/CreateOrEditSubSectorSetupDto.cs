using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CreateOrEditSubSectorSetupDto : EntityDto<int?>
    {

        public string Section { get; set; }

        public string SubHeading { get; set; }

    }
}