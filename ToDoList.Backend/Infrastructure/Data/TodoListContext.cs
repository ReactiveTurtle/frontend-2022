using Microsoft.EntityFrameworkCore;
using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Infrastructure.Data.TodoModel.EntityConfigurations;
using To_Do_List_Backend.Infrastructure.UoW;

namespace To_Do_List_Backend.Infrastructure;

public class TodoListContext : DbContext, IUnitOfWork
{
    public TodoListContext( DbContextOptions<TodoListContext> options ) : base( options )
    {
    }

    public DbSet<Todo> Todo { get; set; }

    protected override void OnModelCreating( ModelBuilder builder )
    {
        base.OnModelCreating( builder );
        builder.ApplyConfiguration( new TodoMap() );
    }

    public async Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default )
    {
        await SaveChangesAsync( cancellationToken );

        return true;
    }
}
