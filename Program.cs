using HotelListing_API.Data;
using HotelListing_API.IRepository;
using HotelListing_API.ConfigurationsAndMappings;
using HotelListing_API.Repository;
using HotelListing_API.ServicesExtension;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;
using HotelListing_API.Services;

var builder =WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//this must be registered for a request in the controller to function
builder.Services.AddTransient<IWorkDone, WorkDone>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

builder.Services.AddControllers().AddNewtonsoftJson(option =>
        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddPolicy("MyCorPolicy", builder=> builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

//register the automapper in the services
builder.Services.AddAutoMapper(typeof(MapperInitializer));

//register serilog logger to the services---hand written
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console().WriteTo.Seq("http://localhost:5341/"));


//This is to register the identity configuration service from the
//ServiceExtension folder into the program class
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    ////
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");
app.UseAuthentication();
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


