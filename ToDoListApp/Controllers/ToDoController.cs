using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using Entities;
using System.Web.Mvc;

namespace ToDoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        // Listeleme
        public ActionResult Index()
        {
            var todos = _todoService.GetAll();
            return View(todos);
        }

        // Ekleme sayfası GET
        public ActionResult Create()
        {
            return View();
        }

        // Ekleme POST
        [HttpPost]
        public ActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                todo.CreatedAt = DateTime.Now;
                _todoService.Add(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // Güncelleme GET
        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetById(id);
            return View(todo);
        }

        // Güncelleme POST
        [HttpPost]
       
        public ActionResult Edit(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.Update(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // Silme GET
        public ActionResult Delete(int id)
        {
            var todo = _todoService.GetById(id);
            return View(todo);
        }

        // Silme POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _todoService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}