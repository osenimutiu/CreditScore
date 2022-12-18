using System.Collections.Generic;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate.Exporting
{
    public interface ISubHeadingSetupsExcelExporter
    {
        FileDto ExportToFile(List<GetSubHeadingSetupForViewDto> subHeadingSetups);
    }
}