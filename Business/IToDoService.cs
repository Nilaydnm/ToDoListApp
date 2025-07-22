using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public interface IToDoService
    {
        List<ToDo> GetAll();
        ToDo GetById(int id);
        void Add(ToDo todo);
        void Update(ToDo todo);
        void Delete(int id);
    }
}
