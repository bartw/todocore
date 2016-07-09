using TodoApi.Models;
using System.Collections.Generic;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(int id);
        TodoItem Remove(int id);
        void Update(TodoItem item);
    }
}