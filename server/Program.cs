using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using server.Models;
using server.Interfaces;
using server.Providers;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlite("Data Source=todo.db"));


builder.Services.AddScoped<DbToDoProvider>();
builder.Services.AddScoped<IToDoProvider, DbToDoProvider>(); 
builder.Services.AddSingleton<InMemoryToDoProvider>();         


builder.Services.AddScoped<ToDoProviderFactory>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();