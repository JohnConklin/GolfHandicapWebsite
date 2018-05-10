using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GolfHandicapCalculator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolfHandicapCalculator.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserContext context;

        public UsersController(UserContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet("test")]
        public bool Get()
        {
            return Auth.IsValidToken(Request.Headers["Authorization"]);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Users/register
        [HttpPost]
        public string Post([FromBody]User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(u => u.UserName == user.UserName);

            if (foundUser != null)
            {
                return "Username is not available";
            }

            user.Salt = Auth.GenerateSalt();
            user.Password = Auth.Hash(user.Password, user.Salt);
            context.Users.Add(user);
            context.SaveChanges();
            return Auth.GenerateJWT(user);
        }

        //Users login
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            UserVM vm = new UserVM();

            User foundUser = context.Users.SingleOrDefault<User>(u => u.UserName == user.UserName && u.Password == Auth.Hash(user.Password, u.Salt));

            vm.UserID = foundUser.Id;
            vm.UserName = foundUser.UserName;

            if (foundUser != null)
            {
                return Ok(vm);
               
            }


            return BadRequest("You failed to pass authentication!!!");

        }


    }
}