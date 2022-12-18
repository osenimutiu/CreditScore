using System.Collections.Generic;
using IFRSDemo.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace IFRSDemo.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
