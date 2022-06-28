using HotChocolate.Types.Pagination;
using HotChocolateTest.Domain;
using HotChocolateTest.GraphQL.QueryResolvers;

namespace HotChocolateTest.GraphQL.QueryTypes;

public class FooTypeExtensions : ObjectTypeExtension
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Query);

        descriptor.Field(nameof(FooResolvers.GetFooByCountry))
            .Name("foos")
            .Description("Get foos for a country.")
            .Type<ListType<NonNullType<FooObjectType>>>()
            .Argument("country", x =>
                x.Description("The country code")
                    .Type<NonNullType<StringType>>())
            .Argument("id", x =>
                x.Description("The id of foo")
                    .Type<IdType>())
            .Argument("status", x =>
                x.Description("A status indicating foo is active or inactive.")
                    .DefaultValue(Status.Active)
                    .Type<StatusEnumType>())
            .UsePaging(options: new PagingOptions
            {
                MaxPageSize = 20,
                DefaultPageSize = 15,
                IncludeTotalCount = true
            })
            .UseSorting<FooSortInputType>()
            .ResolveWith<FooResolvers>(_ => _.GetFooByCountry(default, default, default, default));
    }
}