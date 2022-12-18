using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.LogisticRegression.Dto
{
   public class GetLogRegressionForViewDto : EntityDto
    {
        public double Location { get; set; }
        public double Rent_bin { get; set; }
        public double Rent_to_Income_bin { get; set; }
        public double Return_on_Assets_bin { get; set; }
        public double Total_assets_bin { get; set; }
        public bool Good_Bad { get; set; }
        public string Training_Test { get; set; }
    }

    public class RegOutputDto : EntityDto
    {
        public string ParamName { get; set; }
        public double Coeff_Estimate { get; set; }
        public double Std_Error { get; set; }
        public double t_value { get; set; }
        public double p_value { get; set; }
    }
    public class GetAllRegOutputInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string ParamNameFilter { get; set; }
        public string Coeff_EstimateFilter { get; set; }
        public string Std_ErrorFilter { get; set; }
        public string t_valueFilter { get; set; }
        public string p_valueFilter { get; set; }
    }

    public class RegOutputRunDataDto : EntityDto
    {
        public DateTime RunDate { get; set; }
    }

    public class LogisticRegressionOutputDto : EntityDto
    {
        public double coefficients { get; set; }
        public string name { get; set; }
    }


}
