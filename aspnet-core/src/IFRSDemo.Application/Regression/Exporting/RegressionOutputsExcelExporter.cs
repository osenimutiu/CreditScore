using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using IFRSDemo.DataExporting.Excel.NPOI;
using IFRSDemo.Regression.Dtos;
using IFRSDemo.Dto;
using IFRSDemo.Storage;

namespace IFRSDemo.Regression.Exporting
{
    public class RegressionOutputsExcelExporter : NpoiExcelExporterBase, IRegressionOutputsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public RegressionOutputsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetRegressionOutputForViewDto> regressionOutputs)
        {
            return CreateExcelPackage(
                "RegressionOutputs.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("RegressionOutputs"));

                    AddHeader(
                        sheet,
                        L("ParamName"),
                        L("Coeff_Estimate"),
                        L("Std_Error"),
                        L("t_value"),
                        L("p_value")
                        );

                    AddObjects(
                        sheet, 2, regressionOutputs,
                        _ => _.RegressionOutput.ParamName,
                        _ => _.RegressionOutput.Coeff_Estimate,
                        _ => _.RegressionOutput.Std_Error,
                        _ => _.RegressionOutput.t_value,
                        _ => _.RegressionOutput.p_value
                        );

                });
        }
    }
}