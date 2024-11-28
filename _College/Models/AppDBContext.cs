using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Numerics;

namespace _College.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(
                j => j.HasKey(sc => new {sc.SudentId,sc.CourseId})
             );
            modelBuilder.Entity<DoctorCourse>(
                j => j.HasKey(sc => new { sc.DoctorId, sc.CourseId })
             );

        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<DoctorCourse> DoctorCourses { get; set; }
        
    }
}
