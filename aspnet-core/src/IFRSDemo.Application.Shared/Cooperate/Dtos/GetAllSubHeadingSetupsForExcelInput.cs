﻿using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllSubHeadingSetupsForExcelInput
    {
        public string Filter { get; set; }

        public string SubHeadingFilter { get; set; }

        public string SectionSetupSectionFilter { get; set; }

    }
}