using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    public interface ISeverityRepository : IRepository<Tbl_Severity, int>
    {
        //void PostSeverity(double param1, double param2, double param3, double param4, double param5, double param6,
        //    double param8, double param9, double param10, double param11, double param12, double param13, double param14, double param15,
        //    double param16, double param17, double param18, double param19, double param20, double param21, double param22, double param23,
        //    double param24, double param25, double param26, double param27, double param28, double param29, double param30, double param31,
        //    double param32, double param33, double param34, double param35, double param36, double param37, double param38, double param39,
        //    double param40, double param41, double param42);
        void PostBDS(double param1, double param2, double param3, double param4, double param5, double param6);
        void PostCLEDS(double param8, double param9, double param10, double param11, double param12, double param13);
        void PostFDS(double param14, double param15, double param16);
        void PostFCDS(double param17, double param18, double param19, double param20, double param21);
        void PostNFRDS(double param22, double param23);
        void CBDS(double param24, double param25, double param26, double param27, double param28, double param29, double param30, double param31,
            double param32, double param33, double param34, double param35, double param36, /*double param37,*/ double param38, double param39,
            double param40, double param41, double param42);
        void GenerateScoreAllocation();
    }
}
