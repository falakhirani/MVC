using MVC_WEB_APP;
using MVC_WEB_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_WEB_APP.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDBContext _db;

        public SubjectController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Subject> listofsubjects = _db.Subject;
            return View(listofsubjects);
        }

        [HttpGet]
        public IActionResult Edit(int subjectid)
        {
            var subobj = _db.Subject.Find(subjectid);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Subject updatedvaluesobj)
        {
            _db.Subject.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

       
    }
}
