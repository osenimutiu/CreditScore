using System.Collections.Generic;
using IFRSDemo.Authorization.Users.Dto;
using IFRSDemo.Dto;

namespace IFRSDemo.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}