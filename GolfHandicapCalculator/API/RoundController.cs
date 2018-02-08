﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfHandicapCalculator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicapCalculator.API
{
    [Route("api/[controller]")]
    public class RoundController : Controller
    {
        private UserContext _db;

        public RoundController(UserContext db)
        {
            this._db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Round> Get()
        {
            return _db.Rounds.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rounds = _db.Rounds.FirstOrDefault(g => g.RoundID == id);
            if (rounds == null)
            {
                return NotFound();
            }
            return Ok(rounds);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (round.RoundID == 0)
            {
                //Add course
                _db.Rounds.Add(round);
                _db.SaveChanges();
            }
            else
            {
                //Update Round
                //Calculate Handicap Differential:  (Score - Course Rating) x 113 / Slope Rating    --FOR EACH INDIVIDUAL ROUND

                var orginal = _db.Rounds.FirstOrDefault(g => g.RoundID == round.RoundID);
                orginal.HoleScore = round.HoleScore;
                orginal.RoundDifferential = round.RoundDifferential;
                _db.SaveChanges();
            }
            return Ok(round);

        }
    }
}
