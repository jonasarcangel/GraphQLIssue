using GraphQL.Types;
using GraphQLIssue.Core.Entities;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Api.Models
{
    public class ConfigType : ObjectGraphType<Config>
    {
        public ConfigType(IConfigRepository configRepository)
        {
            Field(x => x.Tenant, nullable:true);
            Field(x => x.Id, nullable:true);
            Field(x => x.Name, nullable:true);
            Field(x => x.CreatedBy, nullable:true);
            Field(x => x.CreatedDate, nullable:true);
            Field(x => x.UpdatedBy, nullable:true);
            Field(x => x.UpdatedDate, nullable:true);
            
            Field(x => x.Module, nullable:true);
            Field(x => x.Value, nullable:true);
        }
    }
}