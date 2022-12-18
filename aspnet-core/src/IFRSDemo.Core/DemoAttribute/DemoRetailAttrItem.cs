using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DemoAttribute
{
   public class DemoRetailAttrItem : Entity<int>
    {
        public string Attribute { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
    }

    public class SubRetailAttrItem : Entity<int>
    {
        public string AttributeId { get; set; }
        public string SubAttribute { get; set; }
        public double Value { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }

    public class RetailCustomer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNo { get; set; }
        public string BVN { get; set; }
    }
    public class RetailScore : Entity<int>
    {
        public int NameId { get; set; }
        public double Score { get; set; }
        public string ApprovalStatus { get; set; }
    }
    public class DemoRetailCutOff : Entity<int>
    {
        public double CuttOff { get; set; }
    }

    public class RetailCustomerDetail : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNo { get; set; }
        public string BVN { get; set; }
    }
}
