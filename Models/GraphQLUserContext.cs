using System.Security.Claims;

namespace GraphQLIssue.Api.Models
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}