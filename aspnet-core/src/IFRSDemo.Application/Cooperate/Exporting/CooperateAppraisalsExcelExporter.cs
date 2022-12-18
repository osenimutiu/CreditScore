using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class CooperateAppraisalsExcelExporter : NpoiExcelExporterBase, ICooperateAppraisalsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CooperateAppraisalsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCooperateAppraisalForViewDto> cooperateAppraisals)
        {
            return CreateExcelPackage(
                "CooperateAppraisals.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("CooperateAppraisals"));

                    AddHeader(
                        sheet,
                        L("CompanyName"),
                        L("RCNumber"),
                        L("AccountNumber"),
                        L("Score"),
                        (L("SetupQualitative")) + L("Qualitative")
                        );

                    AddObjects(
                        sheet, 2, cooperateAppraisals,
                        _ => _.CooperateAppraisal.CompanyName,
                        _ => _.CooperateAppraisal.RCNumber,
                        _ => _.CooperateAppraisal.AccountNumber,
                        _ => _.CooperateAppraisal.Score,
                        _ => _.SetupQualitativeQualitative
                        );

                });
        }
    }
}