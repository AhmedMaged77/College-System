using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _College.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorCourse>(
                j => j.HasKey(sc => new { sc.DoctorId, sc.CourseId })
             );

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorCourse> DoctorCourses { get; set; }

    }
}
