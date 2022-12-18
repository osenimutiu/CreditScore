using GraphQL.Types;
using IFRSDemo.Dto;

namespace IFRSDemo.Types
{
    public class OrganizationUnitType : ObjectGraphType<OrganizationUnitDto>
    {
        public OrganizationUnitType()
        {
            Field(x => x.Id);
            Field(x => x.Code);
            Field(x => x.DisplayName);
            Field(x => x.TenantId, nullable: true);
        }
    }
}