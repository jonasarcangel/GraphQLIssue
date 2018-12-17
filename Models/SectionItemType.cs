using GraphQL.Types;
using GraphQLIssue.Core.Entities;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Api.Models
{
    public class SectionItemType : ObjectGraphType<SectionItem>
    {
        public SectionItemType(ISectionItemRepository sectionItemRepository)
        {
            Field(x => x.Tenant, nullable:true);
            Field(x => x.Id, nullable:true);
            Field(x => x.Name, nullable:true);
            Field(x => x.CreatedBy, nullable:true);
            Field(x => x.CreatedDate, nullable:true);
            Field(x => x.UpdatedBy, nullable:true);
            Field(x => x.UpdatedDate, nullable:true);
            Field(x => x.ParentId, nullable:true);
            
            Field(x => x.Section, nullable:true);
            Field(x => x.PathUrl, nullable:true);
            Field(x => x.PathName, nullable:true);
            Field(x => x.Alias, nullable:true);
            Field(x => x.Description, nullable:true);
            //Field<StringGraphType>("modules", resolve: context => context.Source.Modules);
        }
    }
}