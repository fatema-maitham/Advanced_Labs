using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2_Collections
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Private field for salary 
        protected double salary;

        // Full property with validation 
        public virtual double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
            }
        }

        public Employee(int id, string firstName, string lastName, double salary)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        // Virtual method for salary updates 
        public virtual void UpdateSalary(double incrementPercent)
        {
            salary += salary * incrementPercent;
        }

        // Display method 
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {FirstName} {LastName}, Salary: {Salary:C}");
        }
    }
}
