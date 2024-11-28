using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _College.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(
                j => j.HasKey(sc => new { sc.StudentId, sc.CourseId })
             );
            modelBuilder.Entity<DoctorCourse>(
                j => j.HasKey(sc => new { sc.DoctorId, sc.CourseId })
             );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<DoctorCourse> DoctorCourses { get; set; }

    }
}
