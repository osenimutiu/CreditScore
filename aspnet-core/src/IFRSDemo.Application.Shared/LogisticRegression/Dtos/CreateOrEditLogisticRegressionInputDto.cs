using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.LogisticRegression.Dtos
{
    public class CreateOrEditLogisticRegressionInputDto : EntityDto<int?>
    {

        public decimal Location { get; set; }

        public decimal Rent_bin { get; set; }

        public decimal Rent_to_Income_bin { get; set; }

        public decimal Return_on_Assets_bin { get; set; }

        public decimal Total_assets_bin { get; set; }

        public bool Good_Bad { get; set; }

    }
}