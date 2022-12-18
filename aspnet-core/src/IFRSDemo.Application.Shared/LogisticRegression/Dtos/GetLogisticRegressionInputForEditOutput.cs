using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.LogisticRegression.Dtos
{
    public class GetLogisticRegressionInputForEditOutput
    {
        public CreateOrEditLogisticRegressionInputDto LogisticRegressionInput { get; set; }

    }
}