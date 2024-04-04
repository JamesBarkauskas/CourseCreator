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
    }
}
