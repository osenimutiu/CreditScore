using Abp.AspNetCore.Mvc.ViewComponents;

namespace IFRSDemo.Web.Public.Views
{
    public abstract class IFRSDemoViewComponent : AbpViewComponent
    {
        protected IFRSDemoViewComponent()
        {
            LocalizationSourceName = IFRSDemoConsts.LocalizationSourceName;
        }
    }
}