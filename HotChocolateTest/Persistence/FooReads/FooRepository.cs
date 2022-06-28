using HotChocolateTest.Application.FooReads;

namespace HotChocolateTest.Persistence.FooReads;

public class FooRepository : IFooRepository
{
    private readonly IEnumerable<ActiveFooReadModel> _active = new[]
    {
        new ActiveFooReadModel
        {
            IdentifierField = "1A",
            Country = "NL",
            A = "Foo 1 A",
            B = 1.1m,
            C = "Foo 1 C"
        },
        new ActiveFooReadModel
        {
            IdentifierField = "2B",
            Country = "NL",
            A = "Foo 2 A",
            B = 0.2m,
            C = "Foo 2 C"
        },
        new ActiveFooReadModel
        {
            IdentifierField = "3C",
            Country = "DE",
            A = "Foo 3 A",
            B = 3.3m,
            C = "Foo 3 C"
        },
        new ActiveFooReadModel
        {
            IdentifierField = "4D",
            Country = "DE",
            A = "Foo 4 A",
            B = 0.4m,
            C = "Foo 4 C"
        }
    };

    private readonly IEnumerable<InactiveFooReadModel> _inactive = new[]
    {
        new InactiveFooReadModel
        {
            IdentifierField = "5E",
            Country = "NL",
            A = "Foo 5 A",
            B = 5.5m,
            D = "Foo 5 D"
        },
        new InactiveFooReadModel
        {
            IdentifierField = "6F",
            Country = "NL",
            A = "Foo 6 A",
            B = 0.6m,
            D = "Foo 6 D"
        },
        new InactiveFooReadModel
        {
            IdentifierField = "7G",
            Country = "DE",
            A = "Foo 7 A",
            B = 7.7m,
            D = "Foo 7 D"
        },
        new InactiveFooReadModel
        {
            IdentifierField = "8H",
            Country = "DE",
            A = "Foo 8 A",
            B = 0.8m,
            D = "Foo 8 D"
        }
    };

    public IReadOnlyList<ActiveFooReadModel> GetActive(string country)
    {
        return this._active.Where(f => f.Country == country).ToList();
    }

    public IReadOnlyList<InactiveFooReadModel> GetInactive(string country)
    {
        return this._inactive.Where(f => f.Country == country).ToList();
    }

    public ActiveFooReadModel? TryGetActive(string country, string id)
    {
        return this._active.FirstOrDefault(f => f.Country == country && f.IdentifierField == id);
    }

    public InactiveFooReadModel? TryGetInactive(string country, string id)
    {
        return this._inactive.FirstOrDefault(f => f.Country == country && f.IdentifierField == id);
    }
}