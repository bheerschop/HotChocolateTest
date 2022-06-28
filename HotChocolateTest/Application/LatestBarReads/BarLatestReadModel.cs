namespace HotChocolateTest.Application.LatestBarReads;

public record BarLatestReadModel(
    string Identifier,
    int X,
    int Y,
    decimal Z);