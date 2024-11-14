using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using TodoAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDBContext") ?? throw new InvalidOperationException("Connection string 'TodoDBContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<TodoDBContext>();
    context.Database.Migrate();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
