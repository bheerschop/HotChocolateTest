namespace HotChocolateTest.GraphQL;

public record Foo(
    string Identifier,
    string Country,
    string A,
    decimal B,
    string? C,
    string? D)
{
    public Bar? Bar { get; set; }
    public decimal CalculatedValue { get; set; }
}