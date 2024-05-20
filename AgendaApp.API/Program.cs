using AgendaApp.API.Extensions;
using AgendaApp.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddDependecyInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddCorsConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCorsConfig();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

