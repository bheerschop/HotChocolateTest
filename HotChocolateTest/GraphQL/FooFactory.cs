using HotChocolateTest.Application.FooReads;

namespace HotChocolateTest.GraphQL;

internal static class FooFactory
{
    public static Foo CreateFoo(ActiveFooReadModel model)
    {
        return new Foo(model.IdentifierField, model.Country, model.A, model.B, model.C, null);
    }

    public static Foo CreateFoo(InactiveFooReadModel model)
    {
        return new Foo(model.IdentifierField, model.Country, model.A, model.B, null, model.D);
    }
}