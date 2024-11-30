using Microsoft.EntityFrameworkCore;
//importing the entities so program can reference the entity for Students collection.
using StudentPortal.Models.Entities;
namespace StudentPortal.Data
{
    //FROM entityframework core inheriting dbcontext 
    public class ApplicationDbContext : DbContext
    {
        //injecting dbcontext options into the applicationdbcontext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }   
        //Collection of stydent types in program
        //The dbcontext is the bridge for database and application
        //then we can do  CRUP using this students variable.   plays vital role for database          

        //the student type  can be seen using ctrl click on ?student> thts the type of data
        public DbSet<Student> Students { get; set; }
    }
}
