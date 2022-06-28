using HotChocolateTest.Application.LatestBarReads;

namespace HotChocolateTest.Persistence.LatestBarReads;

public class LatestBarRepository : ILatestBarRepository
{
    private readonly IEnumerable<BarLatestReadModel> _barLatestReadModels = new List<BarLatestReadModel>
    {
        new("1A", 1, 8, 11.5m),
        new("2B", 2, 7, 10.4m),
        new("3C", 3, 6, 9.3m),
        new("4D", 4, 5, 8.2m)
    };

    public IReadOnlyList<BarLatestReadModel> GetLatestBarsForIdentifiers(IEnumerable<string> identifiers)
    {
        return this._barLatestReadModels.Where(b => identifiers.Contains(b.Identifier)).ToList();
    }
}