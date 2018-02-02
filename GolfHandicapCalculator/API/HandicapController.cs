using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfHandicapCalculator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicapCalculator.API
{
    [Route("api/[controller]")]
    public class HandicapController : Controller
    {
        private UserContext _db;

        public HandicapController(UserContext db)
        {
            this._db = db;
        }

        // GET: api/<controller>  Display list of courses
        [HttpGet]
        public IEnumerable<Handicap> Get()
        {
            var handicap = _db.HandiCaps.ToList();
            return handicap;
        }

        // GET api/<controller>/5  Display list of courses by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var handicap = _db.HandiCaps.FirstOrDefault(g => g.HandiCapID == id);
            if (handicap == null)
            {
                return NotFound();
            }
            return Ok(handicap);
        }

        //Post new courses to database or update is already loaded.
        [HttpPost]
        public IActionResult Post([FromBody]Handicap handicap)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (handicap.HandiCapID == 0)
            {
                //Add handicap
                _db.HandiCaps.Add(handicap);
                _db.SaveChanges();
            }
            else
            {
                //Update Handicap
                var orginal = _db.HandiCaps.FirstOrDefault(g => g.HandiCapID == handicap.HandiCapID);
                orginal.HandiCapValue = handicap.HandiCapValue;
                _db.SaveChanges();
            }
            return Ok(handicap);
        }
    }
}
