using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapCalculator.Models
{
    public class Round
    {
        public int RoundID { get; set; }
        public int HoleScore { get; set; }
        public ICollection<GolfCourse> GolfCourse { get; set; }  //Course ID
    }
}
