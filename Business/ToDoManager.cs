using System;
using System.Text;
using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ToDoManager : IToDoService
    {
        private readonly ToDoContext _context;

        public ToDoManager(ToDoContext context)
        {
            _context = context;  // Dependency injection ile ToDoContext'i alıyoruz
        }

        public void Add(ToDo todo)
        {
            _context.ToDos.Add(todo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = _context.ToDos.Find(id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                _context.SaveChanges();
            }
        }

        public List<ToDo> GetAll()
        {
            return _context.ToDos.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public ToDo GetById(int id)
        {
            return _context.ToDos.Find(id);
        }

        public void Update(ToDo todo)
        {
            var entity = _context.ToDos.Find(todo.Id);
            if (entity != null)
            {
                entity.Title = todo.Title;
                entity.IsCompleted = todo.IsCompleted;
                _context.SaveChanges();
            }
        }
    }
}
