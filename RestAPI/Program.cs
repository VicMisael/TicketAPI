using Infra.Persistence;
using RestAPI.Common;
using RestAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUseCases();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseSwaggerUI();
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
}


app.MapControllers();
app.UseHttpsRedirection();



app.Run();

