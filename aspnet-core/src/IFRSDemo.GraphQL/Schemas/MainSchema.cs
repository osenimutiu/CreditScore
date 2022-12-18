using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using IFRSDemo.Queries.Container;

namespace IFRSDemo.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}