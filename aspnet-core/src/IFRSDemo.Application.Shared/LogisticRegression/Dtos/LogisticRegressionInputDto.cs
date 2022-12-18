using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.LogisticRegression.Dtos
{
    public class LogisticRegressionInputDto : EntityDto
    {
        public double Location { get; set; }

        public double Rent_bin { get; set; }

        public double Rent_to_Income_bin { get; set; }

        public double Return_on_Assets_bin { get; set; }

        public double Total_assets_bin { get; set; }

        public bool Good_Bad { get; set; }

        public bool Training_Test { get; set; }

        

    }
}