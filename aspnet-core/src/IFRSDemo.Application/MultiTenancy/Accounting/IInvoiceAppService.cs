using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using IFRSDemo.MultiTenancy.Accounting.Dto;

namespace IFRSDemo.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
