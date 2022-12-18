using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class SetupQualitativesExcelExporter : NpoiExcelExporterBase, ISetupQualitativesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SetupQualitativesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSetupQualitativeForViewDto> setupQualitatives)
        {
            return CreateExcelPackage(
                "SetupQualitatives.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SetupQualitatives"));

                    AddHeader(
                        sheet,
                        L("Qualitative"),
                        L("Value"),
                        L("Status"),
                        (L("SectionSetup")) + L("Section"),
                        (L("SetupSubHeading")) + L("SubHeading")
                        );

                    AddObjects(
                        sheet, 2, setupQualitatives,
                        _ => _.SetupQualitative.Qualitative,
                        _ => _.SetupQualitative.Value,
                        _ => _.SetupQualitative.Status,
                        _ => _.SectionSetupSection,
                        _ => _.SetupSubHeadingSubHeading
                        );

                });
        }
    }
}