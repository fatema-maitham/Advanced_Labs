using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._1_CodeFirst.Models
{
    public class Instructor
    {
        //Lab Exercises 
        /*Complete the following exercises to reinforce the concepts covered in this lab. 
        Exercise 1: Extend the Model 
        • Add a new entity class called Instructor with properties: Id, FirstName, LastName,
        Department, and HireDate. 
        • Add a DbSet<Instructor> property to the AppDbContext. 
        • Run Add-Migration AddInstructor and Update-Database to update the database. 
        • Verify the new table in SQL Server Object Explorer. 
        • Add at least 3 Instructor records and display them in the console.*/
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
    }
}
