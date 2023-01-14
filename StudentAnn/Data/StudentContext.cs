using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAnn.Models;

namespace StudentAnn.Data
{
    public class StudentContext: IdentityDbContext
    {
        //option pour faire les configuration de identitydbcontext
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }

    }
}
