using System.Collections.Generic;
using IFRSDemo.Auditing.Dto;
using IFRSDemo.Dto;

namespace IFRSDemo.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
