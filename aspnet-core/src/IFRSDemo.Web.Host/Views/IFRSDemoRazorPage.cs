using Abp.AspNetCore.Mvc.Views;

namespace IFRSDemo.Web.Views
{
    public abstract class IFRSDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected IFRSDemoRazorPage()
        {
            LocalizationSourceName = IFRSDemoConsts.LocalizationSourceName;
        }
    }
}
