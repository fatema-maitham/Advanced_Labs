using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._1_OOP
{
    public class Employee
    {
        /*
         Modify the Employee class to add the following validations: 
        • FirstName and LastName cannot be empty or null. 
        • ID must be a positive number. 
        • Display an error message to the console if invalid values are provided.
        */
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected double salary;
        public virtual double Salary 
        {
            get { return salary; }
            set 
            {
                if (value >= 0)
                {
                    salary = value;
                }
            }
        }

        public Employee(int id, string firstName, string lastName, double salary)
        {
            // Validate ID
            if (id <=0)
            {
                Console.WriteLine("Error: ID must be a positive number. Setting ID to 1 by default.");
                ID = 1;
            }
            else 
            {
                ID = id;
            }
            // Validate FirstName
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Error: FirstName cannot be empty. Setting default FirstName = 'Unknown'.");
                FirstName = "Unknown";
            }
            else
            {
                FirstName = firstName;
            }

            // Validate LastName
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Error: LastName cannot be empty. Setting default LastName = 'Unknown'.");
                LastName = "Unknown";
            }
            else
            {
                LastName = lastName;
            }

            // Validate salary (optional)
            Salary = salary >= 0 ? salary : 0;
        }

        public virtual void UpdateSalary(double incrementPercent)
        {
            salary+=salary* incrementPercent;
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {FirstName} {LastName}, Salary: {salary:C}");
        }
    }
}
