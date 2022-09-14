using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(opt =>
//         opt.UseNpgsql(builder.Configuration.GetConnectionString("LearningRemoteDbConnection"), options => options.MigrationsAssembly("WebApi")));

builder.Services.AddDbContext<ApiDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("LearningRemoteDbConnection"), options => options.MigrationsAssembly("WebApi")));

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

app.MigrateDatabase();

app.Run();
