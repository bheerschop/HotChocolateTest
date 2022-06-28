using HotChocolateTest.GraphQL.DataLoaders;

namespace HotChocolateTest.GraphQL.QueryResolvers;

public class BarResolvers
{
    public async Task<Bar> GetLatestByFoo(
        [Parent] Foo foo,
        BarLatestBatchDataLoader dataLoader)
    {
        return await dataLoader.LoadAsync(foo.Identifier);
    }
}