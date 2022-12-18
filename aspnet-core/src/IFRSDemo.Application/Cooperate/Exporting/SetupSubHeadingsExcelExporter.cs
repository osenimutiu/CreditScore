using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class SetupSubHeadingsExcelExporter : NpoiExcelExporterBase, ISetupSubHeadingsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SetupSubHeadingsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSetupSubHeadingForViewDto> setupSubHeadings)
        {
            return CreateExcelPackage(
                "SetupSubHeadings.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SetupSubHeadings"));

                    AddHeader(
                        sheet,
                        L("SubHeading"),
                        (L("SectionSetup")) + L("Section")
                        );

                    AddObjects(
                        sheet, 2, setupSubHeadings,
                        _ => _.SetupSubHeading.SubHeading,
                        _ => _.SectionSetupSection
                        );

                });
        }
    }
}