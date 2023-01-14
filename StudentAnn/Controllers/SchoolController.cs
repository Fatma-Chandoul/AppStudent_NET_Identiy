using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAnn.Models;
using StudentAnn.Models.Repositories;

namespace StudentAnn.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
   // [Authorize]
    public class SchoolController : Controller
    {
        // GET: SchoolController
        ISchoolRepository schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
               this.schoolRepository = schoolRepository;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var schools=schoolRepository.GetAll();
            return View(schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.studentCount=schoolRepository.StudentCount(id);
            ViewBag.studentAgeAverage=schoolRepository.StudentAgeAverage(id);
            var school=schoolRepository.GetById(id);    
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school)
        {
            
              /*  if (ModelState.IsValid)
                {*/
                    schoolRepository.Add(school);
                   return RedirectToAction(nameof(Index));
            /*  }
         else { 
             return View();
         }*/

        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School newschool)
        {
            try
            {
                schoolRepository.Edit(newschool);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school= schoolRepository.GetById(id);   
            return View(school);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School school )
        {
            try
            {
                schoolRepository.Delete(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
