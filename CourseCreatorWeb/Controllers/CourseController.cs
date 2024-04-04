using CourseCreatorWeb.Data;
using CourseCreatorWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseCreatorWeb.Controllers
{
    public class CourseController : Controller
    {
        // first create instance of appDbContext so we can use it to make queries in our action methods
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()    // index page of Courses where we want to display a table with all the current courses
        {
            List<Course> courseList = _db.Courses.ToList();

            return View(courseList);
        }

        public IActionResult Details(int? id)
        {
            List<Course> courses = new List<Course>();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Course? course = _db.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            courses.Add(course);
            return View(courses);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Course? course = _db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Course course = _db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Course course = _db.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
