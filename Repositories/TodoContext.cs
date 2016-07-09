using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./todo.db");
        }
    }
}