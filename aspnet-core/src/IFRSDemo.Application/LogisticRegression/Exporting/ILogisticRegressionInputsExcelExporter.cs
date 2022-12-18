using System.Collections.Generic;
using IFRSDemo.LogisticRegression.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.LogisticRegression.Exporting
{
    public interface ILogisticRegressionInputsExcelExporter
    {
        FileDto ExportToFile(List<GetLogisticRegressionInputForViewDto> logisticRegressionInputs);
    }
}