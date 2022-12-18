using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Regression.Dtos
{
    public class RegressionOutputDto : EntityDto
    {
        public string ParamName { get; set; }

        public double Coeff_Estimate { get; set; }

        public double Std_Error { get; set; }

        public double t_value { get; set; }

        public double p_value { get; set; }

    }
}