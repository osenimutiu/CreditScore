﻿using Abp.Application.Services.Dto;

namespace IFRSDemo.LogisticRegression.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}