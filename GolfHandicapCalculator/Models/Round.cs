﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapCalculator.Models
{
    public class Round
    {
        public int RoundID { get; set; }
        public int HoleScore { get; set; }
        public string CourseName { get; set; }
        public int RoundDifferential { get; set; }
       // public ICollection<User> User { get; set; }  //User ID
       public string UserID { get; set; }
    }
}
