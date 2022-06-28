using HotChocolateTest.Application.FooReads;
using HotChocolateTest.Application.LatestBarReads;
using HotChocolateTest.GraphQL;
using HotChocolateTest.GraphQL.DataLoaders;
using HotChocolateTest.GraphQL.QueryTypes;
using HotChocolateTest.Persistence.FooReads;
using HotChocolateTest.Persistence.LatestBarReads;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFooRepository, FooRepository>();
builder.Services.AddScoped<ILatestBarRepository, LatestBarRepository>();

builder.Services.AddGraphQLServer()
    .AddQueryType(_ => _.Name(OperationTypeNames.Query))
    .AddType<FooTypeExtensions>()
    .AddType<FooObjectType>()
    .AddDataLoader<BarLatestBatchDataLoader>()
    .AddFiltering()
    .AddSorting()
    .ModifyOptions(options => options.DefaultBindingBehavior = BindingBehavior.Explicit)
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .InitializeOnStartup();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();