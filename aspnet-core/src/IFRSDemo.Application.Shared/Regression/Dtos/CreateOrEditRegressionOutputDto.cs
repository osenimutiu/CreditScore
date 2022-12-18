using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Regression.Dtos
{
    public class CreateOrEditRegressionOutputDto : EntityDto<int?>
    {

        [Required]
        public string ParamName { get; set; }

        public decimal Coeff_Estimate { get; set; }

        public decimal Std_Error { get; set; }

        public decimal t_value { get; set; }

        public decimal p_value { get; set; }

    }
}