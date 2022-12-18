using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using IFRSDemo.Dto;

namespace IFRSDemo.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
