using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Cooperate.Exporting
{
    public class SubSectorSetupsExcelExporter : NpoiExcelExporterBase, ISubSectorSetupsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SubSectorSetupsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSubSectorSetupForViewDto> subSectorSetups)
        {
            return CreateExcelPackage(
                "SubSectorSetups.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("SubSectorSetups"));

                    AddHeader(
                        sheet,
                        L("Section"),
                        L("SubHeading")
                        );

                    AddObjects(
                        sheet, 2, subSectorSetups,
                        _ => _.SubSectorSetup.Section,
                        _ => _.SubSectorSetup.SubHeading
                        );

                });
        }
    }
}