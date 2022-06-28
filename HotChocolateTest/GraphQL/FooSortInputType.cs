using HotChocolate.Data.Sorting;

namespace HotChocolateTest.GraphQL;

public class FooSortInputType : SortInputType<Foo>
{
    protected override void Configure(ISortInputTypeDescriptor<Foo> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.A);
        descriptor.Field(f => f.B);
        descriptor.Field(f => f.Bar);
        descriptor.Field(f => f.CalculatedValue);
    }
}