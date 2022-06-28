using HotChocolateTest.Application.LatestBarReads;

namespace HotChocolateTest.GraphQL;

internal static class BarFactory
{
    public static Bar CreateBar(BarLatestReadModel model)
    {
        return new Bar(model.Identifier, model.X, model.Y, model.Z);
    }
}