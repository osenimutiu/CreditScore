using System.Collections.Generic;
using IFRSDemo.Regression.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Regression.Exporting
{
    public interface IRegressionOutputsExcelExporter
    {
        FileDto ExportToFile(List<GetRegressionOutputForViewDto> regressionOutputs);
    }
}