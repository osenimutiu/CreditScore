using System.Collections.Generic;
using IFRSDemo.Authorization.Users.Importing.Dto;
using IFRSDemo.Dto;

namespace IFRSDemo.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
