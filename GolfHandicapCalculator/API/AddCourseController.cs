using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfHandicapCalculator.Models;

//API File 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicapCalculator.API
{
    [Route("api/[controller]")]
    public class AddCourseController : Controller
    {
        private UserContext _db;

        public AddCourseController(UserContext db)
        {
            this._db = db;
        }

        // GET: api/<controller>  Display list of courses
        [HttpGet]
        public IEnumerable<GolfCourse> Get()
        {
            return _db.GolfCourses.ToList();
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
                 var orginal = _db.GolfCourses.FirstOrDefault(g => g.GolfCourseID == course.GolfCourseID);
                 orginal.Name = course.Name;
                 orginal.Rating = course.Rating;
                 orginal.Slope = course.Slope;
                 _db.SaveChanges();
             }
             return Ok(course);
         }

 


    }
}
