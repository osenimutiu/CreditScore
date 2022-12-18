using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SetUp.Dto
{
   public class SetUpItemListDto : EntityDto
    {
        public int Training { get; set; }
        public int Test { get; set; }
        public string Email { get; set; }
        public string Method { get; set; }
        public string SplittingMethod { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
    public class GetSetUpItemForEditOutput
    {
        public int Id { get; set; }
        public int Training { get; set; }
        public int Test { get; set; }
        public string Email { get; set; }
        public int MethodId { get; set; }
        public int SplittingMethodId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
    public class GetSetUpItemForEditInput
    {
        public int Id { get; set; }
    }
    public class EditSetUpItemInput
    {
        public int Id { get; set; }
        public int Training { get; set; }
        public int Test { get; set; }
        public string Email { get; set; }
        public int MethodId { get; set; }
        public int SplittingMethodId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}
