using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class SectionSetupsExcelExporter : NpoiExcelExporterBase, ISectionSetupsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SectionSetupsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSectionSetupForViewDto> sectionSetups)
        {
            return CreateExcelPackage(
                "SectionSetups.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SectionSetups"));

                    AddHeader(
                        sheet,
                        L("Section"),
                        L("Position"),
                        L("Active")
                        );

                    AddObjects(
                        sheet, 2, sectionSetups,
                        _ => _.SectionSetup.Section,
                        _ => _.SectionSetup.Position,
                        _ => _.SectionSetup.Active
                        );

                });
        }
    }
}