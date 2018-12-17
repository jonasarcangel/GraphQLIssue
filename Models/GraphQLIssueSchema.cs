using GraphQL;
using GraphQL.Types;

namespace GraphQLIssue.Api.Models
{
    public class GraphQLIssueSchema : Schema
    {
        public GraphQLIssueSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<GraphQLIssueQuery>();
            Mutation = resolver.Resolve<GraphQLIssueMutation>();
        }
    }
}