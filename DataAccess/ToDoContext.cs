using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entities;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=ToDoContext") 
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
