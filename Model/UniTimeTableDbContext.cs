// BlogDbContext.cs
using Microsoft.EntityFrameworkCore;


namespace  UniversityTimeTableModel { 

public class UniversityTimeTableDbContext : DbContext
{
    public DbSet<Courses> Course { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<LevelDepartment> LevelDepartments {get; set;}
    public DbSet<SLOT>  slots {get; set;}
    public DbSet<LevelCourse> LevelCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set up MySQL database connection here.
        string connectionString = "server=localhost;database=UniTimetable;user=root;password=root;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the primary keys of the StudentCourse entity
        modelBuilder.Entity<LevelCourse>()
            .HasKey(sc => new { sc.LevelDepartmentId, sc.CoursesId });

        // Configure the many-to-many relationship between Student and Course
        modelBuilder.Entity<LevelCourse>()
            .HasOne(sc => sc.LevelDepartmental)
            .WithMany(s => s.LevelCourse)
            .HasForeignKey(sc => sc.LevelDepartmentId);

          modelBuilder.Entity<LevelCourse>()
            .HasOne(sc => sc.course)
            .WithMany(c => c.LevelCourse)
            .HasForeignKey(sc => sc.CoursesId);


            modelBuilder.Entity<SLOT>()
            .HasMany(a => a.Courses) // One Author has many Books
            .WithOne(b => b.SLOT) // One Book belongs to one Author
            .HasForeignKey(b => b.SLOTId); 
    }

    
}


}