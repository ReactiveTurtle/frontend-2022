using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Dto;
using To_Do_List_Backend.Infrastructure.Data.TodoModel;
using To_Do_List_Backend.Infrastructure.UoW;

namespace To_Do_List_Backend.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoService( ITodoRepository todoRepository, IUnitOfWork unitOfWork )
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Todo> GetTodos()
        {
            return _todoRepository.GetTodos();
        }

        public void CompleteTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            todo.SetComplete();
            _todoRepository.Update( todo );

            _unitOfWork.SaveEntitiesAsync();
        }

        public int CreateTodo( TodoDto todo )
        {
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found" );
            }

            Todo todoEntity = todo.ConvertToTodo();

            int id = _todoRepository.Create( todoEntity );
            _unitOfWork.SaveEntitiesAsync();

            return id;
        }

        public void DeleteTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            _todoRepository.Delete( todo );
            _unitOfWork.SaveEntitiesAsync();
        }

        public Todo GetTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            return todo;
        }
    }
}
