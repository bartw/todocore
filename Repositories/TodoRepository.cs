using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using TodoApi.Models;
using System.Linq;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public TodoRepository()
        {
        }

        public IEnumerable<TodoItem> GetAll()
        {
            using (var db = new TodoContext())
            {
                Console.WriteLine(db.TodoItems.Count().ToString());
                return db.TodoItems.ToList();
            }
        }

        public void Add(TodoItem item)
        {
            using (var db = new TodoContext())
            {
                db.TodoItems.Add(item);
                db.SaveChanges();
            }
        }

        public TodoItem Find(int id)
        {
            using (var db = new TodoContext())
            {
                return db.TodoItems.FirstOrDefault(ti => ti.Id == id);
            }
        }

        public TodoItem Remove(int id)
        {
            using (var db = new TodoContext())
            {
                var item = db.TodoItems.FirstOrDefault(ti => ti.Id == id);
                db.TodoItems.Remove(item);
                return item;
            }
        }

        public void Update(TodoItem item)
        {
            using (var db = new TodoContext())
            {
                var itemFromDb = db.TodoItems.FirstOrDefault(ti => ti.Id == item.Id);
                itemFromDb.Text = item.Text;
                itemFromDb.IsComplete = item.IsComplete;
                db.SaveChanges();
            }
        }
    }
}