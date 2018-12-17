using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using GraphQL.Types;
using GraphQLIssue.Core.Entities;
using GraphQLIssue.Core.Repositories;
using GraphQLIssue.Api.Services;

namespace GraphQLIssue.Api.Models
{
    public class GraphQLIssueMutation : ObjectGraphType
    {
        private IConfigRepository _configRepository;
        private IAccessService _accessService;

        public GraphQLIssueMutation(
            ISectionRepository sectionRepository,
            ISectionItemRepository sectionItemRepository,
            IContentItemRepository contentItemRepository,
            IConfigRepository configRepository,
            IAccessService accessService
        )
        {
            _configRepository = configRepository;
            _accessService = accessService;

            Field<SectionType>(
                "addOrUpdateSection",
                arguments: new QueryArguments(
                    // <SectionInputType>
                    new QueryArgument<NonNullGraphType<SectionInputType>> { Name = "section" }
                ),
                resolve: context =>
                {
                    var section = context.GetArgument<Section>("section");
                    this.StampItem(section);
                    return sectionRepository.AddOrUpdate(section);
                });

            Field<SectionItemType>(
                "addOrUpdateSectionItem",
                arguments: new QueryArguments(
                    // <SectionInputType>
                    new QueryArgument<NonNullGraphType<SectionItemInputType>> { Name = "sectionItem" }
                ),
                resolve: context =>
                {
                    var sectionItem = context.GetArgument<SectionItem>("sectionItem");
                    this.StampItem(sectionItem);
                    return sectionItemRepository.AddOrUpdate(sectionItem);
                });

            Field<ContentItemType>(
                "addOrUpdateContentItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ContentItemInputType>> { Name = "contentItem" },
                    new QueryArgument<StringGraphType> { Name = "sectionItems" }
                ),
                resolve: context =>
                {
                    var contentItem = context.GetArgument<ContentItem>("contentItem");
                    var sectionItems = context.GetArgument<String>("sectionItems");
                    if (_accessService.Allowed(contentItem).Result)
                    {
                        this.StampItem(contentItem);
                        var userId = _accessService.GetCurrentUserId();
                        var isAdmin = _accessService.IsAdmin();
                        return contentItemRepository.AddOrUpdate(contentItem, sectionItems, userId, isAdmin);
                    }
                    else
                    {
                        return new ContentItem();
                    }
                });

            Field<ConfigType>(
                "addOrUpdateConfig",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ConfigInputType>> { Name = "config" }
                ),
                resolve: context =>
                {
                    var config = context.GetArgument<Config>("config");
                    this.StampItem(config);
                    return configRepository.AddOrUpdate(config);
                });
        }

        private void StampItem(Item item) 
        {
            string user = _accessService.GetCurrentUserId();

            if (string.IsNullOrEmpty(item.Id)) 
            {
                item.CreatedBy = user;
                item.CreatedDate = DateTimeOffset.UtcNow;
            } 
            else 
            {
                item.UpdatedBy = user;
                item.UpdatedDate = DateTimeOffset.UtcNow;
            }
        }


        private async Task<bool> Active(ContentItem contentItem)
        {
            List<Config> config = await _configRepository.Get("", contentItem.Module, "isActive");

            if (config.Count > 0)
            {
                return config[0].Value == "y";
            }

            return false;
        }
     }
}