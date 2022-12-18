using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.LogisticRegression.Dtos
{
    public class GetAllLogisticRegressionInputsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public double? MaxLocationFilter { get; set; }
        public double? MinLocationFilter { get; set; }

        public double? MaxRent_binFilter { get; set; }
        public double? MinRent_binFilter { get; set; }

        public double? MaxRent_to_Income_binFilter { get; set; }
        public double? MinRent_to_Income_binFilter { get; set; }

        public double? MaxReturn_on_Assets_binFilter { get; set; }
        public double? MinReturn_on_Assets_binFilter { get; set; }

        public double? MaxTotal_assets_binFilter { get; set; }
        public double? MinTotal_assets_binFilter { get; set; }

        public int? Good_BadFilter { get; set; }

        public int? Training_TestFilter { get; set; }


    }
}