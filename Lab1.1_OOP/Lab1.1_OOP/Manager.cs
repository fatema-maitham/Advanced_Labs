using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._1_OOP
{
    public class Manager: Employee
    {
        // Add a private attribute for department (string). 
        private string department;

        // Create a custom constructor that accepts all Employee attributes plus department
        public Manager(int id, string firstName, string lastName, double salary, string department): base(id, firstName, lastName, salary)
        {
            this.department = department;
        }

        // Override the UpdateSalary method to give managers a 1.5x increment (50% more than regular employees).
        public override void UpdateSalary(double incrementPercent)
        {
            double managerIncrement = incrementPercent * 1.5;
            base.UpdateSalary(managerIncrement);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {FirstName} {LastName}, Department: {department}, Salary: {Salary:C}");
        }
    }
}
