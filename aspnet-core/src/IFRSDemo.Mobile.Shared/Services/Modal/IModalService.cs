using System.Threading.Tasks;
using IFRSDemo.Views;
using Xamarin.Forms;

namespace IFRSDemo.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
