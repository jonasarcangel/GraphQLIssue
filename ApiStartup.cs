using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GraphQLIssue.Core.Repositories;
using GraphQLIssue.Data.Repositories;
using GraphQLIssue.Api.Models;
using GraphQLIssue.Api.Services;

namespace GraphQLIssue.Api
{
  public class ApiStartup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<IDocumentWriter, DocumentWriter>();
      
      services.AddSingleton<IAccessService, AccessService>();
      services.AddSingleton<GraphQLIssueQuery>();
      services.AddSingleton<GraphQLIssueMutation>();
      services.AddSingleton<SectionType>();
      services.AddSingleton<SectionInputType>();
      services.AddSingleton<SectionItemType>();
      services.AddSingleton<SectionItemInputType>();
      services.AddSingleton<ContentItemType>();
      services.AddSingleton<ContentSectionItemType>();
      services.AddSingleton<ContentItemInputType>();
      services.AddSingleton<ConfigType>();
      services.AddSingleton<ConfigInputType>();
      var sp = services.BuildServiceProvider();
      services.AddSingleton<ISchema>(new GraphQLIssueSchema(new FuncDependencyResolver(type => sp.GetService(type))));

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddGraphQL(_ =>
      {
          _.EnableMetrics = true;
          _.ExposeExceptions = true;
      })
      .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      // add http for Schema at default url /graphql
      //app.UseGraphQL<ISchema>("/graphql");

      // use graphql-playground at default url /ui/playground
      //app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
      //{
          //Path = "/ui/playground"
      //});
    }
  }
}