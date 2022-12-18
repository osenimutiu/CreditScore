using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DemoAttribute.Dto
{
   public class CreateDemoRetailAttrDto
    {
        public string Attribute { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
    }

    public class DemoRetailAttrItemDto : EntityDto
    {
        public string Attribute { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
    }

    public class GetDemoRetailAttrForEditOutput
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
    }

    public class GetDemoRetailAttrForEditInput
    {
        public int Id { get; set; }
    }
    public class EditDemoRetailAttrInput
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
    }

    public class GetSubRetailAttrItemForEditOutput
    {
        public int Id { get; set; }
        public string AttributeId { get; set; }
        public string SubAttribute { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }

    public class GetSubRetailAttrItemForEditInput
    {
        public int Id { get; set; }
    }

    public class EditSubRetailAttrItemInput
    {
        public int Id { get; set; }
        public string AttributeId { get; set; }
        public string SubAttribute { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
    public class CreateSubRetailAttrItemDto
    {
        public string AttributeId { get; set; }
        public string SubAttribute { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }
    }

    public class SubRetailAttrItemDto : EntityDto
    {
        public string Attribute { get; set; }
        public string SubAttribute { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }
    }

    public class ApiResponsesDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class CreateRetailScoreDto
    {
        public int NameId { get; set; }
        public double Score { get; set; }
        public string ApprovalStatus { get; set; }
    }
    public class GetRetailScoreForEditOutput
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public double Score { get; set; }
    }

    public class GetRetailScoreForEditInput
    {
        public int Id { get; set; }
    }

    public class EditRetailScoreInput
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public double Score { get; set; }
    }

    public class DemoRetailCutOffDto
    {
        public double CuttOff { get; set; }
    }

    public class RetailCustomerDetailForEditOutput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNo { get; set; }
        public string BVN { get; set; }
    }

    public class GetRetailCustomerDetailEditInput
    {
        public int Id { get; set; }
    }

    public class RetailCustomerDetailInput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNo { get; set; }
        public string BVN { get; set; }
    }

   

}
