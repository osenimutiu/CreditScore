using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class EditScoringInputDataInput
    {
        public virtual int Id { get; set; }
        public virtual bool TrainingSample { get; set; }
        public virtual string UniqueID { get; set; }
        public virtual int Age { get; set; }
        
        public virtual double Income { get; set; }
        public virtual double ReturnonAssets { get; set; }
        public virtual string Location { get; set; }
        public virtual string Residentstatus { get; set; }
        public virtual double TimeatJob { get; set; }
        public virtual double Timeatresidence { get; set; }
        public virtual string Product { get; set; }
        public virtual string Sector { get; set; }
        public virtual string Subsector { get; set; }
        public virtual string CurrentAccountStatus { get; set; }
        public virtual double Totalassets { get; set; }
        public virtual double Rent { get; set; }
        public virtual double RenttoIncome { get; set; }
        public virtual double TimeatBank { get; set; }
        public virtual int Numberofproducts { get; set; }
        public virtual string Paymentperformance { get; set; }
        public virtual bool Previousclaims { get; set; }
        public virtual bool GoodBad { get; set; }
        public virtual string Dateopened { get; set; }
    }

    public class GetScoringInputDataForEditOutput
    {
        public virtual int Id { get; set; }
        public virtual bool TrainingSample { get; set; }
        public virtual string UniqueID { get; set; }
        public virtual int Age { get; set; }

        public virtual double Income { get; set; }
        public virtual double ReturnonAssets { get; set; }
        public virtual string Location { get; set; }
        public virtual string Residentstatus { get; set; }
        public virtual double TimeatJob { get; set; }
        public virtual double Timeatresidence { get; set; }
        public virtual string Product { get; set; }
        public virtual string Sector { get; set; }
        public virtual string Subsector { get; set; }
        public virtual string CurrentAccountStatus { get; set; }
        public virtual double Totalassets { get; set; }
        public virtual double Rent { get; set; }
        public virtual double RenttoIncome { get; set; }
        public virtual double TimeatBank { get; set; }
        public virtual int Numberofproducts { get; set; }
        public virtual string Paymentperformance { get; set; }
        public virtual bool Previousclaims { get; set; }
        public virtual bool GoodBad { get; set; }
        public virtual string Dateopened { get; set; }

    }

    public class GetScoringInputDataForEditInput
    {
        public int Id { get; set; }
    }
}
