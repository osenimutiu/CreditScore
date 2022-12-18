using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllQualitativeSetupsForExcelInput
    {
        public string Filter { get; set; }

        public string SectionFilter { get; set; }

        public string SubHeadingFilter { get; set; }

        public string QualitativeFilter { get; set; }

        public int? MaxValueFilter { get; set; }
        public int? MinValueFilter { get; set; }

        public int? StatusFilter { get; set; }

    }
}