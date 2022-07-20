using To_Do_List_Backend.Infrastructure;
using To_Do_List_Backend.Services;
using Microsoft.EntityFrameworkCore;
using To_Do_List_Backend.Infrastructure.Data.TodoModel;
using To_Do_List_Backend.Infrastructure.UoW;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoListContext>( c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>( "DefaultConnection" );
        c.UseSqlServer( connectionString );
    }
    catch ( Exception )
    {
        //var message = ex.Message;
    }
} );
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();
app.MapControllers();
app.Run();
app.UseCors( x => x
    .WithOrigins( "http://localhost:4200" )
    .AllowCredentials()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader() );
