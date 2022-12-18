using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("TblScoringInputDatas")]
    public class ScoringInputData : FullAuditedEntity, IMayHaveTenant
    {
        public const int MaxIncomeLength = 32;
        public virtual bool TrainingSample { get; set; }
        public virtual string UniqueID { get; set; }
        public virtual int Age { get; set; }
        [Required]
        [MaxLength(MaxIncomeLength)]
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
        public int? TenantId { get; set; }

        public ScoringInputData(bool trainingSample, string uniqueID, int age, double income, double returnonAssets, string location, string residentstatus, double timeatresidence, double timeatJob, string product, string sector, string subsector, string currentAccountStatus, double totalassets, double rent, double renttoIncome, double timeatBank, int numberofproducts, string paymentperformance, bool previousclaims, bool goodBad, string dateopened, int? tenantId)
        {
            TrainingSample = trainingSample;
            UniqueID = uniqueID;
            Age = age;
            Income = income;
            ReturnonAssets = returnonAssets;
            Location = location;
            Residentstatus = residentstatus;
            Timeatresidence = timeatresidence;
            TimeatJob = timeatJob;
            Product = product;
            Sector = sector;
            Subsector = subsector;
            CurrentAccountStatus = currentAccountStatus;
            Totalassets = totalassets;
            Rent = rent;
            RenttoIncome = renttoIncome;
            TimeatBank = timeatBank;
            Numberofproducts = numberofproducts;
            Paymentperformance = paymentperformance;
            Previousclaims = previousclaims;
            GoodBad = goodBad;
            Dateopened = dateopened;
            TenantId = tenantId;
            
        }

        public ScoringInputData()
        {

        }


    }
}
