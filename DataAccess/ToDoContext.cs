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
        public ToDoContext() : base("name=ToDoContext") // Web.config'e yazacağız
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
