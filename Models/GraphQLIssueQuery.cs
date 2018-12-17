using System;
using GraphQL.Types;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Api.Models
{
    public class GraphQLIssueQuery : ObjectGraphType
    {
        public GraphQLIssueQuery(
            ISectionRepository sectionRepository,
            ISectionItemRepository sectionItemRepository,
            IContentItemRepository contentItemRepository,
            IConfigRepository configRepository)
        {
            Field<ListGraphType<SectionType>>(
                "sections",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { 
                        Name = "id" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "module" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "name" 
                    }
                    ),
                resolve: context =>  sectionRepository.Get(
                    context.GetArgument<string>("id"),
                    context.GetArgument<string>("module"),
                    context.GetArgument<string>("name")
                    ));

            Field<ListGraphType<SectionItemType>>(
                "sectionItems",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { 
                        Name = "id" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "section" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "pathUrl" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "alias" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "name" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "parentId" 
                    },
                    new QueryArgument<BooleanGraphType> { 
                        Name = "isRoot" 
                    }
                    ),
                resolve: context =>  sectionItemRepository.Get(
                    context.GetArgument<string>("id"),
                    context.GetArgument<string>("section"),
                    context.GetArgument<string>("pathUrl"),
                    context.GetArgument<string>("alias"),
                    context.GetArgument<string>("name"),
                    context.GetArgument<string>("parentId"),
                    context.GetArgument<bool>("isRoot")
                    )
                );

            Field<ListGraphType<ContentItemType>>(
                "contentItems",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { 
                        Name = "id" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "name" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "alias" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "module" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "parentId" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "createdBy" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "sectionItems" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "content" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute01" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute02" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute03" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute04" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute05" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute06" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute07" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute08" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute09" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute10" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute11" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute12" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute13" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute14" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute15" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute16" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute17" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute18" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute19" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "attribute20" 
                    },
                    new QueryArgument<BooleanGraphType> { 
                        Name = "includeChildren" 
                    },
                    new QueryArgument<BooleanGraphType> { 
                        Name = "includeParents" 
                    }
                    ),
                resolve: context =>  contentItemRepository.Get(
                    context.GetArgument<string>("id"),
                    context.GetArgument<string>("name"),
                    context.GetArgument<string>("alias"),
                    context.GetArgument<string>("module"),
                    context.GetArgument<string>("parentId"),
                    context.GetArgument<string>("createdBy"),
                    context.GetArgument<string>("sectionItems"),
                    context.GetArgument<string>("content"),
                    context.GetArgument<string>("attribute01"),
                    context.GetArgument<string>("attribute02"),
                    context.GetArgument<string>("attribute03"),
                    context.GetArgument<string>("attribute04"),
                    context.GetArgument<string>("attribute05"),
                    context.GetArgument<string>("attribute06"),
                    context.GetArgument<string>("attribute07"),
                    context.GetArgument<string>("attribute08"),
                    context.GetArgument<string>("attribute09"),
                    context.GetArgument<string>("attribute10"),
                    context.GetArgument<string>("attribute11"),
                    context.GetArgument<string>("attribute12"),
                    context.GetArgument<string>("attribute13"),
                    context.GetArgument<string>("attribute14"),
                    context.GetArgument<string>("attribute15"),
                    context.GetArgument<string>("attribute16"),
                    context.GetArgument<string>("attribute17"),
                    context.GetArgument<string>("attribute18"),
                    context.GetArgument<string>("attribute19"),
                    context.GetArgument<string>("attribute20"),
                    context.GetArgument<bool>("includeChildren"),
                    context.GetArgument<bool>("includeParents")
                    )
                );            

            Field<ListGraphType<ConfigType>>(
                "configs",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { 
                        Name = "id" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "module" 
                    },
                    new QueryArgument<StringGraphType> { 
                        Name = "name" 
                    }
                    ),
                resolve: context => configRepository.Get(
                    context.GetArgument<string>("id"),
                    context.GetArgument<string>("module"),
                    context.GetArgument<string>("name")
                    ));
        }
    }
}
