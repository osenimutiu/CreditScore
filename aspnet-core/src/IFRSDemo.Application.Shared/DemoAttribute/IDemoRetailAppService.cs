using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.DemoAttribute.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.DemoAttribute
{
    public interface IDemoRetailAppService : IApplicationService
    {
        Task CreateDemoRetailAttrItem(CreateDemoRetailAttrDto input);
        List<DemoRetailAttrItemDto> GetDemoRetailAttrItem();
        IEnumerable<Object> GetApprovedSubRetailAttr(string AttributeParam);
        Task<GetDemoRetailAttrForEditOutput> GetDemoRetailAttrEdit(GetDemoRetailAttrForEditInput input);
        Task EditDemoRetailAttr(EditDemoRetailAttrInput input);
        Task DeleteDemoRetailAttr(EntityDto input);
        IEnumerable<string> DistinctAttribute();
        //Task CreateSubRetailAttrItem(CreateSubRetailAttrItemDto input);
        ApiResponsesDto CreateSubRetailAttrItem(CreateSubRetailAttrItemDto input);

        Task<GetSubRetailAttrItemForEditOutput> GetSubRetailAttrItemEdit(GetSubRetailAttrItemForEditInput input);
        Task EditSubRetailAttrItem(EditSubRetailAttrItemInput input);
        IEnumerable<Object> GetSubRetailAttrItem();
        void ApproveAttribute(int param1, string param2);
        void DeclineAttribute(int param1, string param2);
        ApiResponsesDto InsertNewCustomerScore(string param1, string param2, string param3, string param4, double param5);
        ApiResponsesDto AddExistingCustomerScore(CreateRetailScoreDto input);
        IEnumerable<Object> GetDetailScores();
        IEnumerable<Object> GetExistingCustomer();
        void ReverseAttribute(int param1);

        
        Task<GetRetailScoreForEditOutput> GetRetailScoreItemEdit(GetRetailScoreForEditInput input);
        Task EditRetailScore(EditRetailScoreInput input);
        bool AddCutOff(DemoRetailCutOffDto input);
        IEnumerable<Object> GetCutOff();
        Task<RetailCustomerDetailForEditOutput> GetRetailCustomerDetailEdit(GetRetailCustomerDetailEditInput input);
        Task EditRetailCustomerDetail(RetailCustomerDetailInput input);
        IEnumerable<Object> GetRetailCustomerDetail();
        Task UpdateStatus(int id, string param);

    }
}
