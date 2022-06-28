namespace HotChocolateTest.GraphQL;

public record Bar(string Identifier,
    int X,
    int Y,
    decimal Z)
{
    public decimal CalculatedValue { get; set; }
}