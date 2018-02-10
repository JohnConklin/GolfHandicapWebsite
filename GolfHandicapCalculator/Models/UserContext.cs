using Microsoft.EntityFrameworkCore;

namespace GolfHandicapCalculator.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }

    }
}
