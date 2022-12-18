using Abp.Domain.Repositories;
using IFRSDemo.DigitalLending.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IFRSDemo.DigitalLending
{
    public class SeverityAppService : IFRSDemoAppServiceBase, ISeverityAppService
    {
        private readonly IRepository<Tbl_Severity> _repository;
        private readonly ISeverityRepository _seveRepo;
        public SeverityAppService(IRepository<Tbl_Severity> repository, ISeverityRepository seveRepo)
        {
            _repository = repository;
            _seveRepo = seveRepo;
        }

        public void PostBDS(double param1, double param2, double param3, double param4, double param5, double param6)
        {
            _seveRepo.PostBDS(param1,param2,param3,param4,param5,param6);
        }
        public void PostCLEDS(double param8, double param9, double param10, double param11, double param12, double param13)
        {
            _seveRepo.PostCLEDS(param8, param9, param10, param11, param12, param13);
        }
        public void PostFDS(double param14, double param15, double param16)
        {
            _seveRepo.PostFDS(param14, param15, param16);
        }
        public void PostFCDS(double param17, double param18, double param19, double param20, double param21)
        {
            _seveRepo.PostFCDS(param17, param18, param19, param20, param21);
        }
        public void PostNFRDS(double param22, double param23)
        {
            _seveRepo.PostNFRDS(param22, param23);
        }
        public void CBDS(double param24, double param25, double param26, double param27, double param28, double param29, double param30, double param31,
            double param32, double param33, double param34, double param35, double param36, /*double param37,*/ double param38, double param39,
            double param40, double param41, double param42)
        {
            _seveRepo.CBDS(param24, param25, param26, param27, param28, param29, param30, param31,
             param32, param33, param34, param35, param36, /*param37,*/ param38, param39,
             param40, param41, param42);
        }


        public SeverityDto GetUpdatedSeverity()
        {
            //var one = _repository.GetAll().Where(x => x.Description == "Event of bad debt /collections payment").FirstOrDefault().Severity;
            //var two = (from c in _repository.GetAll() where c.Description == "" select c.Description).FirstOrDefault();
            var one = (from c in _repository.GetAll() where c.Description == "Event of bad debt /collections payment" select c.Severity).FirstOrDefault();
            var two = (from c in _repository.GetAll() where c.Description == "Fraud event" select c.Severity).FirstOrDefault();
            var three = _repository.GetAll().Where(x => x.Description == "Frequent adverse payments").FirstOrDefault().Severity;
            var four = _repository.GetAll().Where(x => x.Description == "Not enough bank account data for scoring < 180 days").FirstOrDefault().Severity;
            var five = _repository.GetAll().Where(x => x.Description == "Major new lending obligations identified").FirstOrDefault().Severity;
            var six = _repository.GetAll().Where(x => x.Description == "Not enough inflows to grant s credit line").FirstOrDefault().Severity;
            var eight = _repository.GetAll().Where(x => x.Description == "Not enough space for a credit line").FirstOrDefault().Severity;
            var nine = _repository.GetAll().Where(x => x.Description == "Affordable credit line amount too low compared to the requested amount").FirstOrDefault().Severity;
            var ten = _repository.GetAll().Where(x => x.Description == "Insufficient bank account buffer").FirstOrDefault().Severity;
            var eleven = _repository.GetAll().Where(x => x.Description == "Insufficient level of inflows versus the stated revenues").FirstOrDefault().Severity;
            var twelve = _repository.GetAll().Where(x => x.Description == "Not enough overdraft buffer available").FirstOrDefault().Severity;
            var thirteen = _repository.GetAll().Where(x => x.Description == "Significant reduction in the bank account inflows").FirstOrDefault().Severity;
            var fourteen = _repository.GetAll().Where(x => x.Description == "High leverage").FirstOrDefault().Severity;
            var fiften = _repository.GetAll().Where(x => x.Description == "Negative or insufficient Debt Service Coverage Ratio").FirstOrDefault().Severity;
            var sixteen = _repository.GetAll().Where(x => x.Description == "Insufficient Profit Margin").FirstOrDefault().Severity;
            var seventeen = _repository.GetAll().Where(x => x.Description == "email address identified as automatically generated").FirstOrDefault().Severity;
            var eighteen = _repository.GetAll().Where(x => x.Description == "email address is from a disposable email service").FirstOrDefault().Severity;
            var nineteen = _repository.GetAll().Where(x => x.Description == "the email address bounces").FirstOrDefault().Severity;
            var twenty = _repository.GetAll().Where(x => x.Description == "No mix records found for domain of the email address").FirstOrDefault().Severity;
            var twentyone = _repository.GetAll().Where(x => x.Description == "connection to the SMTP server fails").FirstOrDefault().Severity;
            var twentytwo = _repository.GetAll().Where(x => x.Description == "Company years in business < 1.5").FirstOrDefault().Severity;
            var twentythree = _repository.GetAll().Where(x => x.Description == "Share capital").FirstOrDefault().Severity;
            var twentyfour = _repository.GetAll().Where(x => x.Description == "Unable to verify user payment accounts").FirstOrDefault().Severity;
            var twentyfive = _repository.GetAll().Where(x => x.Description == "Court actions").FirstOrDefault().Severity;
            var twentysix = _repository.GetAll().Where(x => x.Description == "Court writs").FirstOrDefault().Severity;
            var twentyseven = _repository.GetAll().Where(x => x.Description == "Credit enquries").FirstOrDefault().Severity;
            var twentyeight = _repository.GetAll().Where(x => x.Description == "Default status").FirstOrDefault().Severity;
            var twentynine = _repository.GetAll().Where(x => x.Description == "External administration").FirstOrDefault().Severity;
            var thirty = _repository.GetAll().Where(x => x.Description == "Payment defaults").FirstOrDefault().Severity;
            var thirtyone = _repository.GetAll().Where(x => x.Description == "Petition occurrence").FirstOrDefault().Severity;
            var thirtytwo = _repository.GetAll().Where(x => x.Description == "Current Directorships").FirstOrDefault().Severity;
            var thirtythree = _repository.GetAll().Where(x => x.Description == "Director Age").FirstOrDefault().Severity;
            var thirtyfour = _repository.GetAll().Where(x => x.Description == "Bankruptcy").FirstOrDefault().Severity;
            var thirtyfive = _repository.GetAll().Where(x => x.Description == "Commercial Defaults").FirstOrDefault().Severity;
            var thirtysix = _repository.GetAll().Where(x => x.Description == "Consumer Defaults").FirstOrDefault().Severity;
            //var thirtyseven = _repository.GetAll().Where(x => x.Description == "Court Actions").FirstOrDefault().Severity;
            var thirtyeight = _repository.GetAll().Where(x => x.Description == "Disqualified directorships").FirstOrDefault().Severity;
            var thirtynine = _repository.GetAll().Where(x => x.Description == "Probability of future adverse events").FirstOrDefault().Severity;
            var forty = _repository.GetAll().Where(x => x.Description == "Probability of future serious events").FirstOrDefault().Severity;
            var fortyone = _repository.GetAll().Where(x => x.Description == "Low credit bureau score").FirstOrDefault().Severity;
            var fortytwo = _repository.GetAll().Where(x => x.Description == "Previous Directorships").FirstOrDefault().Severity;
            return new SeverityDto
            {
                param1 = one,
                param2 = two,
                param3 = three,
                param4 = four,
                param5 = five,
                param6 = six,
                param8 = eight,
                param9 = nine,
                param10 = ten,
                param11 = eleven,
                param12 = twelve,
                param13 = thirteen,
                param14 = fourteen,
                param15 = fiften,
                param16 = sixteen,
                param17 = seventeen,
                param18 = eighteen,
                param19 = nineteen,
                param20 = twenty,
                param21 = twentyone,
                param22 = twentytwo,
                param23 = twentythree,
                param24 = twentyfour,
                param25 = twentyfive,
                param26 = twentysix,
                param27 = twentyseven,
                param28 = twentyeight,
                param29 = twentynine,
                param30 = thirty,
                param31 = thirtyone,
                param32 = thirtytwo,
                param33 = thirtythree,
                param34 = thirtyfour,
                param35 = thirtyfive,
                param36 = thirtysix,
                //param37 = thirtyseven,
                param38 = thirtyeight,
                param39 = thirtynine,
                param40 = forty,
                param41 = fortyone,
                param42= fortytwo
            };
        }

        public IEnumerable<Object> GetSeverity()
        {
            var result = _repository.GetAll().Select(x => new
            {
                Category = x.Category,
                Name = x.Name,
                Description = x.Description,
                Severity = x.Severity,
                Id = x.Id
            }).ToArray();
            return result;
        }

    }
}
