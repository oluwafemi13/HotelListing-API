using HotelListing_API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;



var builder =WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddPolicy("MyCorPolicy", builder=> builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

//register serilog logger to the services---hand written
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console().WriteTo.Seq("http://localhost:5341/"));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    ////
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");
app.UseAuthorization();

app.MapControllers();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(path: "C:\\Users\\Decagon\\Desktop\\MyFolder\\Log.txt", 
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{level:u3}] {Message: ij}{NewLine}{Exception}", 
    rollingInterval: RollingInterval.Hour,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information).CreateLogger();

try
{
    Log.Information("Application Is Starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}


