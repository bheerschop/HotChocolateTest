using HotChocolate.Data.Sorting;

namespace HotChocolateTest.GraphQL;

public class BarSortInputType : SortInputType<Bar>
{
    protected override void Configure(ISortInputTypeDescriptor<Bar> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(b => b.X);
        descriptor.Field(b => b.Y);
        descriptor.Field(b => b.CalculatedValue);
    }
}