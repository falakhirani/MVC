using MVC_WEB_APP;
using MVC_WEB_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_WEB_APP.Controllers{
    public class TeacherController : Controller{
         private readonly ApplicationDBContext _db;

         public TeacherController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var teachers = from t in _db.Teacher
                           select t;
            if(!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(s => s.Teacher_name!.Contains(searchString));
            }

            return View(await teachers.ToListAsync());

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subobj = _db.Teacher.Find(id);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Teacher updatedvaluesobj)
        {
            _db.Teacher.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

         //Get Delete
        public IActionResult Delete(int id)
        {

            var listofteachers = _db.Teacher.Find(id);
            return View(listofteachers);
        }


        [HttpPost]
        public IActionResult DeletePost(int TeacherId)
        {
            var listofteachers = _db.Teacher.Find(TeacherId);

            if (ModelState.IsValid)
            {

                _db.Teacher.Remove(listofteachers);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listofteachers);
        }

    }
}