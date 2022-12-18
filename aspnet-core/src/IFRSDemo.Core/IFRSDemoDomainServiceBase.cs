using Abp.Domain.Services;

namespace IFRSDemo
{
    public abstract class IFRSDemoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected IFRSDemoDomainServiceBase()
        {
            LocalizationSourceName = IFRSDemoConsts.LocalizationSourceName;
        }
    }
}
