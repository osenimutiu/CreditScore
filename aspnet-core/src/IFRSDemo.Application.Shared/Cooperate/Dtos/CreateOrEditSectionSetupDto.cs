using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CreateOrEditSectionSetupDto : EntityDto<int?>
    {

        public string Section { get; set; }

        public int Position { get; set; }

        public bool Active { get; set; }

    }
}