using ApiBlockchain6.Miner;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(configure => configure.AddSerilog());

builder.Services.AddSingleton<BlockMiner>()
    .AddSingleton<ContractPool>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{

    Log.Logger = new LoggerConfiguration()
        .WriteTo.File(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/log.txt"),
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Verbose)
                    .CreateLogger();

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Main - Fatal Error");
}
finally
{
    Log.CloseAndFlush();
}