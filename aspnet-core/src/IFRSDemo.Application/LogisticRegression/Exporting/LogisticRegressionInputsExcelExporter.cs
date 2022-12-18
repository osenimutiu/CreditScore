using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.LogisticRegression.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.LogisticRegression.Exporting
{
    public class LogisticRegressionInputsExcelExporter : NpoiExcelExporterBase, ILogisticRegressionInputsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LogisticRegressionInputsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetLogisticRegressionInputForViewDto> logisticRegressionInputs)
        {
            return CreateExcelPackage(
                "LogisticRegressionInputs.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("LogisticRegressionInputs"));

                    AddHeader(
                        sheet,
                        L("Location"),
                        L("Rent_bin"),
                        L("Rent_to_Income_bin"),
                        L("Return_on_Assets_bin"),
                        L("Total_assets_bin"),
                        L("Good_Bad")
                        );

                    AddObjects(
                        sheet, 2, logisticRegressionInputs,
                        _ => _.LogisticRegressionInput.Location,
                        _ => _.LogisticRegressionInput.Rent_bin,
                        _ => _.LogisticRegressionInput.Rent_to_Income_bin,
                        _ => _.LogisticRegressionInput.Return_on_Assets_bin,
                        _ => _.LogisticRegressionInput.Total_assets_bin,
                        _ => _.LogisticRegressionInput.Good_Bad
                        );

                });
        }
    }
}