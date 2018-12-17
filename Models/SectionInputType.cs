using GraphQL.Types;

namespace GraphQLIssue.Api.Models
{
    public class SectionInputType : InputObjectGraphType
    {
        public SectionInputType()
        {
            Name = "SectionInput";

            Field<StringGraphType>("tenant");
            Field<StringGraphType>("id");
            Field<StringGraphType>("name");
            
            Field<StringGraphType>("modules");
        }
    }
}