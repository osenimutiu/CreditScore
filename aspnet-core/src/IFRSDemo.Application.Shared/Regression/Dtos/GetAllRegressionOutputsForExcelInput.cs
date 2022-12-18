using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Regression.Dtos
{
    public class GetAllRegressionOutputsForExcelInput
    {
        public string Filter { get; set; }

        public string ParamNameFilter { get; set; }

        public double? MaxCoeff_EstimateFilter { get; set; }
        public double? MinCoeff_EstimateFilter { get; set; }

        public double? MaxStd_ErrorFilter { get; set; }
        public double? MinStd_ErrorFilter { get; set; }

        public double? Maxt_valueFilter { get; set; }
        public double? Mint_valueFilter { get; set; }

        public double? Maxp_valueFilter { get; set; }
        public double? Minp_valueFilter { get; set; }

    }
}