using HotChocolateTest.GraphQL.QueryResolvers;

namespace HotChocolateTest.GraphQL;

public class FooObjectType : ObjectType<Foo>
{
    protected override void Configure(IObjectTypeDescriptor<Foo> descriptor)
    {
        descriptor.Name("Foo")
            .Description(
                "Description of Foo.");

        descriptor
            .Field(f => f.Identifier)
            .Name("id")
            .Description("A domain identifier for Foo")
            .Type<NonNullType<IdType>>();

        descriptor
            .Field(f => f.A)
            .Description("Description of A")
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(f => f.B)
            .Description("Description of B")
            .Type<NonNullType<DecimalType>>();

        descriptor
            .Field(f => f.C)
            .Description("Description of C")
            .Type<StringType>();

        descriptor
            .Field(f => f.D)
            .Description("Description of D")
            .Type<StringType>();

        descriptor
            .Field(f => f.Bar)
            .Description("")
            .Type<BarObjectType>()
            .UseSorting<BarSortInputType>()
            .ResolveWith<BarResolvers>(r => r.GetLatestByFoo(default, default));

        descriptor
            .Field(f => f.CalculatedValue)
            .Description("Some calculated value.")
            .Type<DecimalType>()
            .Resolve(ctx =>
            {
                var foo = ctx.Parent<Foo>();
                return foo.B * 42;
            });
    }
}