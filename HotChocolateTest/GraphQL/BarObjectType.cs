namespace HotChocolateTest.GraphQL;

public class BarObjectType : ObjectType<Bar>
{
    protected override void Configure(IObjectTypeDescriptor<Bar> descriptor)
    {
        descriptor.Name("Bar")
            .Description("Description of Bar");

        descriptor
            .Field(f => f.Identifier)
            .Name("parentId")
            .Description("Description of ParentId of type Foo")
            .Type<NonNullType<IdType>>();

        descriptor
            .Field(f => f.X)
            .Description("Description of X")
            .Type<NonNullType<IntType>>();

        descriptor
            .Field(f => f.Y)
            .Description("Description of Y")
            .Type<NonNullType<IntType>>();

        descriptor
            .Field(f => f.Z)
            .Description("Description of Z")
            .Type<NonNullType<DecimalType>>();


        descriptor
            .Field(f => f.CalculatedValue)
            .Description("Description of CalculatedValue")
            .Resolve(ctx =>
            {
                var bar = ctx.Parent<Bar>();
                return (bar.X + bar.Y) * bar.Z;
            })
            .Type<DecimalType>();
    }
}