namespace HotChocolateTest.Application.FooReads;

public interface IFooRepository
{
    public IReadOnlyList<ActiveFooReadModel> GetActive(string country);

    public IReadOnlyList<InactiveFooReadModel> GetInactive(string country);

    public ActiveFooReadModel? TryGetActive(string country, string id);

    public InactiveFooReadModel? TryGetInactive(string country, string id);
}