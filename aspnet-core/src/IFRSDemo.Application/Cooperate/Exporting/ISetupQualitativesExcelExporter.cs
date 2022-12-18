using System.Collections.Generic;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate.Exporting
{
    public interface ISetupQualitativesExcelExporter
    {
        FileDto ExportToFile(List<GetSetupQualitativeForViewDto> setupQualitatives);
    }
}