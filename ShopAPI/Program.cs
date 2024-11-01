using Microsoft.EntityFrameworkCore;
using ShopAPI.ApplicationDbContext;
//using ShopAPI.Services;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

// Configure Kestrel server to listen on all interfaces on port 5001
builder.WebHost.UseKestrel()
               .UseUrls("http://0.0.0.0:5001");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();

// Ensure the DbContext is correctly named
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
