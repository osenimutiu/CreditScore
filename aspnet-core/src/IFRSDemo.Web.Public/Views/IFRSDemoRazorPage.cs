using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace IFRSDemo.Web.Public.Views
{
    public abstract class IFRSDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected IFRSDemoRazorPage()
        {
            LocalizationSourceName = IFRSDemoConsts.LocalizationSourceName;
        }
    }
}
