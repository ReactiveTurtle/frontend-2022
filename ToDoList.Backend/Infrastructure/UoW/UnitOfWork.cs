namespace To_Do_List_Backend.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly TodoListContext _ctx;

    public UnitOfWork( TodoListContext ctx )
    {
        _ctx = ctx;
    }

    public async Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default )
    {
        return await _ctx.SaveEntitiesAsync( cancellationToken );
    }
}
