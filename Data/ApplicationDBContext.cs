
using Microsoft.EntityFrameworkCore;
using MVC_WEB_APP.Models;

namespace MVC_WEB_APP
{
   public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Student
        {
            get; set;
        }

        public DbSet<Teacher> Teacher
        {
            get; set;
        }

        public DbSet<Subject>  Subject 
        {
             get; set;
         }
    }
}