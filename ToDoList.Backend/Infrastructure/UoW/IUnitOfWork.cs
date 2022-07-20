namespace To_Do_List_Backend.Infrastructure.UoW;

public interface IUnitOfWork
{
    Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default );
}
