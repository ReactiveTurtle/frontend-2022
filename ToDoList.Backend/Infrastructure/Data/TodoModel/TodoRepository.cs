using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Infrastructure.Data.TodoModel
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoListContext _dbContext;

        public TodoRepository( TodoListContext dbContext )
        {
            _dbContext = dbContext;
        }

        public List<Todo> GetTodos()
        {
            return _dbContext.Todo.ToList();
        }

        public int Create( Todo todo )
        {
            return _dbContext.Todo.Add( todo ).Entity.Id;
        }

        public void Delete( Todo todo )
        {
            _dbContext.Todo.Remove( todo );
        }

        public Todo Get( int id )
        {
            return _dbContext.Todo.SingleOrDefault( todo => todo.Id == id );
        }

        public void Update( Todo todo )
        {
             _dbContext.Todo.Update( todo );
        }
    }
}
