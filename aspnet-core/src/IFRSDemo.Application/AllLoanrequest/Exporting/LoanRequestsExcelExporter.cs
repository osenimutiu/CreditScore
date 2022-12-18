using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.AllLoanrequest.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.AllLoanrequest.Exporting
{
    public class LoanRequestsExcelExporter : NpoiExcelExporterBase, ILoanRequestsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LoanRequestsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetLoanRequestForViewDto> loanRequests)
        {
            return CreateExcelPackage(
                "LoanRequests.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("LoanRequests"));

                    AddHeader(
                        sheet,
                        L("Customer"),
                        L("LoanType"),
                        L("Amount"),
                        L("Tenor"),
                        L("Statua")
                        );

                    AddObjects(
                        sheet, 2, loanRequests,
                        _ => _.LoanRequest.Customer,
                        _ => _.LoanRequest.LoanType,
                        _ => _.LoanRequest.Amount,
                        _ => _.LoanRequest.Tenor,
                        _ => _.LoanRequest.Statua
                        );

                });
        }
    }
}