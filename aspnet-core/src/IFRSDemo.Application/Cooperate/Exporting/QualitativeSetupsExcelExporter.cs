using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class QualitativeSetupsExcelExporter : NpoiExcelExporterBase, IQualitativeSetupsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public QualitativeSetupsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetQualitativeSetupForViewDto> qualitativeSetups)
        {
            return CreateExcelPackage(
                "QualitativeSetups.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("QualitativeSetups"));

                    AddHeader(
                        sheet,
                        L("Section"),
                        L("SubHeading"),
                        L("Qualitative"),
                        L("Value"),
                        L("Status")
                        );

                    AddObjects(
                        sheet, 2, qualitativeSetups,
                        _ => _.QualitativeSetup.Section,
                        _ => _.QualitativeSetup.SubHeading,
                        _ => _.QualitativeSetup.Qualitative,
                        _ => _.QualitativeSetup.Value,
                        _ => _.QualitativeSetup.Status
                        );

                });
        }
    }
}