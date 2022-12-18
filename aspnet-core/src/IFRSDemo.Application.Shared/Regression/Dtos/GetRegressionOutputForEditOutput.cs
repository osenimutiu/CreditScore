using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Regression.Dtos
{
    public class GetRegressionOutputForEditOutput
    {
        public CreateOrEditRegressionOutputDto RegressionOutput { get; set; }

    }
}