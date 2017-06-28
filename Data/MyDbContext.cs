using Microsoft.EntityFrameworkCore;
using pocoinheritance.Models;

namespace pocoinheritance.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Workers { get; set; }

    }
}