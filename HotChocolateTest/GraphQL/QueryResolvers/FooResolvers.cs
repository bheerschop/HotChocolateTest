using HotChocolateTest.Application.FooReads;
using HotChocolateTest.Domain;

namespace HotChocolateTest.GraphQL.QueryResolvers;

public class FooResolvers
{
    public async Task<IQueryable<Foo>> GetFooByCountry(
        [Service] IFooRepository fooRepository,
        string country,
        string id,
        Status status)
    {
        var foos = status switch
        {
            Status.Inactive => GetInactive(fooRepository, country, id),
            _ => GetActive(fooRepository, country, id)
        };
        return foos;
    }

    private IQueryable<Foo> GetActive(IFooRepository fooRepository, string country, string id)
    {
        return string.IsNullOrEmpty(id)
            ? fooRepository.GetActive(country).Select(FooFactory.CreateFoo).AsQueryable()
            : (fooRepository.TryGetActive(country, id) as IList<ActiveFooReadModel> ??
               new List<ActiveFooReadModel>())
            .Select(FooFactory.CreateFoo)
            .AsQueryable();
    }

    private IQueryable<Foo> GetInactive(IFooRepository fooRepository, string country, string id)
    {
        return string.IsNullOrEmpty(id)
            ? fooRepository.GetInactive(country).Select(FooFactory.CreateFoo).AsQueryable()
            : (fooRepository.TryGetInactive(country, id) as IList<InactiveFooReadModel> ??
               new List<InactiveFooReadModel>())
            .Select(FooFactory.CreateFoo)
            .AsQueryable();
    }
}