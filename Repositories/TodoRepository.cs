using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private static int _nextId = 1;
        private static ConcurrentDictionary<int, TodoItem> _todos = new ConcurrentDictionary<int, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Text = "Item1" });
            Add(new TodoItem { Text = "Item2" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Id = _nextId;
            _todos[item.Id] = item;
            _nextId++;
        }

        public TodoItem Find(int id)
        {
            TodoItem item;
            _todos.TryGetValue(id, out item);
            return item;
        }

        public TodoItem Remove(int id)
        {
            TodoItem item;
            _todos.TryGetValue(id, out item);
            _todos.TryRemove(id, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Id] = item;
        }
    }
}