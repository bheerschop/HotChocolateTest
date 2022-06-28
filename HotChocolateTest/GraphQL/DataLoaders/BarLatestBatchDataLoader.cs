using HotChocolateTest.Application.LatestBarReads;

namespace HotChocolateTest.GraphQL.DataLoaders;

public class BarLatestBatchDataLoader : BatchDataLoader<string, Bar>
{
    private readonly ILatestBarRepository _latestBarRepository;

    public BarLatestBatchDataLoader(
        ILatestBarRepository latestBarRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        this._latestBarRepository = latestBarRepository;
    }

    protected override async Task<IReadOnlyDictionary<string, Bar>> LoadBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(this._latestBarRepository.GetLatestBarsForIdentifiers(keys)
            .Select(BarFactory.CreateBar)
            .ToDictionary(b => b.Identifier));
    }
}