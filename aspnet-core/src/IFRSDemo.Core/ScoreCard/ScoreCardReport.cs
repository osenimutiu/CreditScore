using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_ScoreCardReport")]
    public class ScoreCardReport : Entity<int>
    {
        public string Characteristic { get; set; }
        public string CharacteristicBin { get; set; }
        public  double ScoreCardPoints { get; set; }
    }
}
