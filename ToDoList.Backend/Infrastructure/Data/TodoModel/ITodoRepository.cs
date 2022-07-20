using System.Collections.Generic;
using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Infrastructure.Data.TodoModel
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos();
        Todo Get( int id );
        int Create( Todo todo );
        void Delete( Todo todo );
        void Update( Todo todo );
    }
}
