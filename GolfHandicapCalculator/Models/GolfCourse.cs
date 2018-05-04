using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapCalculator.Models
{
    public class GolfCourse
    {
        public string Name { get; set; }
        public int Slope { get; set; }
        public double Rating { get; set; }
        public int GolfCourseID { get; set; }
        public ICollection<User> User { get; set; }  //User ID
    }
}
