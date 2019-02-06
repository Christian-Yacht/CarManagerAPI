using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIassignment2.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace APIassignment2.Domein
{
    public class Assignment2_DbContext : DbContext
    {
        // tables for database
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UsersProjects> UsersProjects { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<SkillsProjects> SkillsProjects { get; set; }


        // instance of DbContext : for options, use options of base class
        public Assignment2_DbContext(DbContextOptions<Assignment2_DbContext> options) 
            : base (options)
            { 
            }

        // instance of DbContext : for options, use options of base class
        public DbSet<APIassignment2.Models.Skill> Skill { get; set; }

        // instance of DbContext : for options, use options of base class
        public DbSet<APIassignment2.Models.Project> Project { get; set; }
    }

    // DesignTimeDbContext toegevoegd omdat:
    // MVC_API heeft geen DbContext. Controller maken in MVC lukt niet omdat hij de foutmelding geeft:
    // "No parameterless constructor is defined for this object"
    // Output zegt:
    // Unable to create an object of type 'Assignment2_DbContext'. Add an implementation of 'IDesignTimeDbContextFactory<Assignment2_DbContext>' to the project, or see https://go.microsoft.com/fwlink/?linkid=851728
    // Bezoek deze website voor hulp mbt tot DesignTimeDbContext. 
    // https://docs.microsoft.com/nl-nl/ef/core/miscellaneous/cli/dbcontext-creation
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<Assignment2_DbContext>
    {
        public Assignment2_DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Assignment2_DbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=API-Database2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                                        // DefaultConnection string
            return new Assignment2_DbContext(optionsBuilder.Options);
        }
    }
}
