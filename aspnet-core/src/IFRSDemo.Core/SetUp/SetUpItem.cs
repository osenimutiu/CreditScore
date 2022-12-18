using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SetUp
{
    public class SetUpItem : Entity<int>
    {
        public int Training { get; set; }
        public int Test { get; set; }
        public string Email { get; set; }
        public int MethodId { get; set; }
        public int SplittingMethodId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}
