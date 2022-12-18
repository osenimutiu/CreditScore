using System.Collections.Generic;
using IFRSDemo.AllLoanrequest.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.AllLoanrequest.Exporting
{
    public interface ILoanRequestsExcelExporter
    {
        FileDto ExportToFile(List<GetLoanRequestForViewDto> loanRequests);
    }
}