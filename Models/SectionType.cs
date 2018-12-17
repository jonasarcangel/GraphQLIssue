using GraphQL.Types;
using GraphQLIssue.Core.Entities;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Api.Models
{
    public class SectionType : ObjectGraphType<Section>
    {
        public SectionType(ISectionRepository sectionRepository)
        {
            Field(x => x.Tenant, nullable:true);
            Field(x => x.Id, nullable:true);
            Field(x => x.Name, nullable:true);
            Field(x => x.CreatedBy, nullable:true);
            Field(x => x.CreatedDate, nullable:true);
            Field(x => x.UpdatedBy, nullable:true);
            Field(x => x.UpdatedDate, nullable:true);
            
            Field(x => x.Modules, nullable:true);

            //Field<StringGraphType>("modules", resolve: context => context.Source.Modules);
        }
    }
}