namespace HotChocolateTest.Application.LatestBarReads;

public interface ILatestBarRepository
{
    IReadOnlyList<BarLatestReadModel> GetLatestBarsForIdentifiers(IEnumerable<string> identifiers);
}