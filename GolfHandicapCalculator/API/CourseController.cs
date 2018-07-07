using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfHandicapCalculator.Models;
using System.Collections.Generic;

//API File 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicapCalculator.API
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private UserContext _db;

        public CourseController(UserContext db)
        {
            this._db = db;
        }

        // GET: api/<controller>  Display list of courses
        [HttpGet]
        public IEnumerable<GolfCourse> Get()
        {
            var courses = _db.GolfCourses.ToList();
            return courses;
        }
        // GET api/<controller>/5  Display list of courses by ID
        [HttpGet("{UserID}")]
        public IActionResult Get(string UserId)
        {
            var golfcourses = _db.GolfCourses.Where(g => g.UserID == "john");
            if (golfcourses == null)
            {
                return NotFound();
            }
            return Ok(golfcourses);
        }

        // GET api/<controller>/5  Display list of courses by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var golfcourses = _db.GolfCourses.FirstOrDefault(g => g.GolfCourseID == id);
            if (golfcourses == null)
            {
                return NotFound();
            }
            return Ok(golfcourses);
        }

        //Post new courses to database or update is already loaded.
        [HttpPost]
         public IActionResult Post([FromBody]GolfCourse course)
         {

             if (!ModelState.IsValid)
             {
                 return BadRequest(this.ModelState);
             }

             if (course.GolfCourseID == 0)
             {
                 //Add course
                 _db.GolfCourses.Add(course);
                 _db.SaveChanges();
             }
             else
             {
                 //Update Course
                 var orginal = _db.GolfCourses.FirstOrDefault(g => g.GolfCourseID == course.GolfCourseID && g.UserID == "john");
                 orginal.Name = course.Name;
                 orginal.Rating = course.Rating;
                 orginal.Slope = course.Slope;
                 orginal.UserID = course.UserID;
                 
                 _db.SaveChanges();
             }
             return Ok(course);
         }
    }
}
