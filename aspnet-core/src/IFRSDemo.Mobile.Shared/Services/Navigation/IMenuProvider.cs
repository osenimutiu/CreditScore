using System.Collections.Generic;
using MvvmHelpers;
using IFRSDemo.Models.NavigationMenu;

namespace IFRSDemo.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}