using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
   
   
     
      
    
    
    
      
    public class RetailCutoff : Entity<int>
    {
        public double CutoffValue { get; set; }
    }
}
