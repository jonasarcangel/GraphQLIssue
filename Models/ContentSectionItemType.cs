using GraphQL.Types;
using GraphQLIssue.Core.Entities;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Api.Models
{
    public class ContentSectionItemType : ObjectGraphType<ContentSectionItem>
    {
        public ContentSectionItemType()
        {
            Field(x => x.SectionItem, type:typeof(SectionItemType),  nullable:true);
        }
    }
}