using System.Collections.Generic;
using Abp;
using IFRSDemo.Chat.Dto;
using IFRSDemo.Dto;

namespace IFRSDemo.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
