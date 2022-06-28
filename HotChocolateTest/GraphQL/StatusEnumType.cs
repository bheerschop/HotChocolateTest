using HotChocolateTest.Domain;

namespace HotChocolateTest.GraphQL;

public class StatusEnumType : EnumType<Status>
{
    protected override void Configure(IEnumTypeDescriptor<Status> descriptor)
    {
        descriptor.Name("Status")
            .Description("Indicates whether foo is active or inactive.");

        descriptor
            .Value(Status.Active)
            .Description("Indicates that foo is active.");

        descriptor
            .Value(Status.Inactive)
            .Description("Indicates that foo is inactive.");
    }
}