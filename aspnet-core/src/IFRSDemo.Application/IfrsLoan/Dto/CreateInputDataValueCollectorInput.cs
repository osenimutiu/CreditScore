using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(InputDataValueCollector))]
    public class CreateInputDataValueCollectorInput
    {
        public int? TenantId { get; set; }
        public string InputValues { get; set; }
        //private static readonly char delimiter = ';';
        //private string _inputValues;
        //[NotMapped]
        //public string[] InputValues { get; set; }
        //public string[] InputValues
        //{
        //    get { return _inputValues.Split(delimiter); }
        //    set
        //    {
        //        _inputValues = string.Join($"{delimiter}", value);
        //    }
        //}
    }
}
