using Microsoft.EntityFrameworkCore;
using System;
using WebApi;
using System.Reflection;
using WebApi.Data;
using WebApi.Repository;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CqrsDbContext>(options =>
               options.UseInMemoryDatabase(databaseName: "CqrsDb"));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(opt =>
//         opt.UseNpgsql(builder.Configuration.GetConnectionString("LearningRemoteDbConnection"), options => options.MigrationsAssembly("WebApi")));

// builder.Services.AddDbContext<ApiDbContext>(opt =>
//         opt.UseNpgsql(builder.Configuration.GetConnectionString("LearningRemoteDbConnection"), options => options.MigrationsAssembly("WebApi")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
