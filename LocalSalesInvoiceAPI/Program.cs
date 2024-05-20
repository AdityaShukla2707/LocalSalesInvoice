using LocalSalesInvoiceDOM.Data;
using LocalSalesInvoiceDOM.Models;
using LocalSalesInvoiceRepo.IRepository;
using LocalSalesInvoiceRepo.Repository;
using LocalSalesInvoiceService.CustomServices;
using LocalSalesInvoiceService.ICustomServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomServices<Country>, CountryServices>();
builder.Services.AddScoped<ICustomServices<State>, StateServices>();
#endregion
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option =>
{
    option.AllowAnyHeader();
    option.AllowAnyOrigin();
    option.AllowAnyMethod();

});

app.UseAuthorization();

app.MapControllers();


app.Run();
