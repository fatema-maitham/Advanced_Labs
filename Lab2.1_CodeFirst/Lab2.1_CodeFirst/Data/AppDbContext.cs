using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Lab2._1_CodeFirst.Models;

namespace Lab2._1_CodeFirst.Data
{
    public class AppDbContext : DbContext
    {
        // Each DbSet is a collection of entities, mapped to a table 
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        // Configure the database connection 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Lab21_UniversityDB; Trusted_Connection = True;");
        }
    }
}
