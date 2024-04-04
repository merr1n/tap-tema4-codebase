using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    // dotnet ef migrations add Initial
    // dotnet ef database update
    public class MyDbContext : DbContext
    {
        //private readonly string _windowsConnectionString = @"Server=.\SQLExpress;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=true";
        //private readonly string _windows2ConnectionString = @"Server=localhost\SQLEXPRESS;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _windows3ConnectionString = @"Data Source=DESKTOP-T077D85;Database=Lab5Database1;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        //  public DbSet<StudentCourse> studentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windows3ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasData(new Student("Edi", "Gabriel", "edisor@gmail.com"),
    new Student("Monica", "Lacramioara", "lacra@gmail.com"),
    new Student("Dan", "Stefan", "btk@gmail.com"));

            builder.Entity<Course>().HasData(new Course("TAP"), new Course("AF"), new Course("Limbaje Formale"), new Course("Practica de specialitate"));

            builder.Entity<User>()
                .HasOne(f => f.Type)
                .WithMany(c => c.Users)
                .HasForeignKey(f => f.TypeId);
        }
    }
}
