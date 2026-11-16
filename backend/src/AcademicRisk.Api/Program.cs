using AcademicRisk.Infrastructure;
using AcademicRisk.Infrastructure.Persistence;
using AcademicRisk.Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment() &&
    app.Configuration.GetValue<bool>("SeedData:Uovt2022Curriculum"))
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider
        .GetRequiredService<AcademicRiskDbContext>();

    await Uovt2022CurriculumSeeder.SeedAsync(db);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
