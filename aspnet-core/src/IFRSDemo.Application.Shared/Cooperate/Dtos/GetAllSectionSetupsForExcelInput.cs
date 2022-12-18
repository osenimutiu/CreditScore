using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllSectionSetupsForExcelInput
    {
        public string Filter { get; set; }

        public string SectionFilter { get; set; }

        public int? MaxPositionFilter { get; set; }
        public int? MinPositionFilter { get; set; }

        public int? ActiveFilter { get; set; }

    }
}