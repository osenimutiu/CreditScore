using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class SubHeadingSetupsExcelExporter : NpoiExcelExporterBase, ISubHeadingSetupsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SubHeadingSetupsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSubHeadingSetupForViewDto> subHeadingSetups)
        {
            return CreateExcelPackage(
                "SubHeadingSetups.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SubHeadingSetups"));

                    AddHeader(
                        sheet,
                        L("SubHeading"),
                        (L("SectionSetup")) + L("Section")
                        );

                    AddObjects(
                        sheet, 2, subHeadingSetups,
                        _ => _.SubHeadingSetup.SubHeading,
                        _ => _.SectionSetupSection
                        );

                });
        }
    }
}