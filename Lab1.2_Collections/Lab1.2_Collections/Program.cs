using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace Lab1._2_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a List to store Employee objects 
            List<Employee> employees = new List<Employee>();

            // Adding employees to the list 
            employees.Add(new Employee(1, "Ahmed", "Ali", 1000));
            employees.Add(new Employee(2, "Sara", "Hassan", 1500));
            employees.Add(new Employee(3, "Mohamed", "Ibrahim", 800));
            employees.Add(new Accountant(4, "Fatima", "Ahmed", 1200, 300));
            employees.Add(new Employee(5, "Mohsen", "Ali", 2000));


            // Displaying all employees 
            Console.WriteLine("All Employees:");

            foreach (Employee emp in employees)
            {
                emp.DisplayInfo();
            }
            Console.WriteLine($"\nTotal employees: {employees.Count}");
            //Console.ReadLine();
            

            // LINQ: Filter employees with salary greater than 1000
            Console.WriteLine("\nEmployees with Salary > 1000:");

            var highEarners = employees.Where(e => e.Salary > 1000);

            foreach(Employee emp in highEarners)
            {
                emp.DisplayInfo();
            }


            // LINQ: Sort employees by salary (highest first) 
            Console.WriteLine("\nEmployees Sorted by Salary (Descending):");
            var sortedBySalary = employees.OrderByDescending(e => e.Salary).ThenBy(e=>e.ID);

            foreach (Employee emp in sortedBySalary)
            {
                emp.DisplayInfo();
            }


            // LINQ: Filter AND sort in a single query 
            Console.WriteLine("\nHigh Earners Sorted by Salary:");

            var filteredAndSorted = employees
                .Where(e=> e.Salary>1000)
                .OrderByDescending(e=> e.Salary);

            foreach (Employee e in filteredAndSorted)
            {
                e.DisplayInfo();
            }


            // LINQ: Aggregation methods 
            Console.WriteLine("\nSalary Statistics:");
            double totalSalary = employees.Sum(e => e.Salary);
            double avgSalary = employees.Average(e => e.Salary);
            double minSalary = employees.Min(e => e.Salary);
            double maxSalary = employees.Max(e => e.Salary);
            int countAbove1000 = employees.Count(e => e.Salary > 1000);

            Console.WriteLine($"Total Salary:   {totalSalary:C}");
            Console.WriteLine($"Average Salary: {avgSalary:C}");
            Console.WriteLine($"Highest Salary: {maxSalary:C}");
            Console.WriteLine($"Lowest Salary:  {minSalary:C}");
            Console.WriteLine($"Employees earning > 1000: {countAbove1000}");


            // LINQ: Find specific employees 
            Console.WriteLine("\nFinding Specific Employees:");

            // Find the employee with ID = 3 
            var emp3 = employees.FirstOrDefault(e => e.ID == 3);
            if (emp3 != null)
            {
                Console.WriteLine("Employee with ID 3:");
                emp3.DisplayInfo();
            }

            var emp99 = employees.FirstOrDefault(e => e.ID == 99);
            if (emp99 != null)
            {
                Console.WriteLine("Employee with ID 99:");
                emp99.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Employee with ID 99 not found.");
            }


            // Create a Dictionary with employee ID as the key 
            Dictionary<int, Employee> employeeDict = new Dictionary<int, Employee>();
            foreach(Employee e in employees)
            {
                //employeeDict[e.ID] = e;
                employeeDict.Add(e.ID, e);

            }
            Console.WriteLine($"Dictionary contains {employeeDict.Count} employees.");


            // Direct access by key 
            Console.WriteLine("\nLooking up employee with ID 2:");

            Employee empById = employeeDict[2];

            empById.DisplayInfo();

            // Safe access using TryGetValue 
            Console.WriteLine("\nLooking up employee with ID 99:");

            if (employeeDict.TryGetValue(99, out Employee foundEmp))
            {
                foundEmp.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Employee with ID 99 not found in dictionary.");
            }

            /* Lab Exercises
            Complete the following exercises to reinforce the concepts covered in this lab.
            
            Exercise 1: Additional LINQ Queries 
            • Find and display all employees whose first name starts with the letter 'A'. 
            • Use LINQ to get only the names (FirstName + LastName) of all employees as a list of 
            strings. 
            • Find the employee with the second-highest salary using LINQ.
            */
            // 1) Employees whose first name starts with 'A'
            Console.WriteLine("\nEmployees whose First Name starts with 'A':");
            var employeesStartingWithA = employees
                .Where(e => e.FirstName.StartsWith("A"));

            foreach(Employee e in employeesStartingWithA)
            {
                e.DisplayInfo();
            }

            // 2) Get only full names as List<string>
            Console.WriteLine("\nList of Employee Full Names:");
            List<string> fullNames = employees
                .Select(e => e.FirstName+" "+ e.LastName)
                .ToList();

            //List<string> fullNames = employees
            //    .Select(e => $"{e.FirstName} {e.LastName}")
            //    .ToList();

            foreach (var name in fullNames)
            {
                Console.WriteLine(name);
            }


            // 3) Employee with the second-highest salary
            Console.WriteLine("\nEmployees with Second-Highest Salary:");

            // Step 1: Get second-highest salary value
            var secondHighestSalary = employees
                .Select(e => e.Salary)
                .Distinct()
                .OrderByDescending(s => s)
                .Skip(1)
                .FirstOrDefault();

            // Step 2: Get ALL employees with that salary
            var secondHighestEmployees = employees
                .Where(e => e.Salary == secondHighestSalary);

            foreach (var emp in secondHighestEmployees)
            {
                emp.DisplayInfo();
            }



            /* Exercise 2: List Manipulation 
            • Remove all employees with a salary below 1000 from the list. 
            • Insert a new employee at the beginning of the list (index 0). 
            • Check if the list contains an employee with ID = 10 and display an appropriate message. */

            // Remove all employees with salary below 1000
            Console.WriteLine("\nRemoving employees with salary < 1000...");
            employees.RemoveAll(e=> e.Salary<1000);
            Console.WriteLine("Employees after removal:");
            foreach (var emp in employees)
            {
                emp.DisplayInfo();
            }

            // Insert a new employee at index 0
            Console.WriteLine("\nInserting new employee at index 0...");

            employees.Insert(0, new Employee(10, "Sayed Ali", "Hasan", 1800));

            Console.WriteLine("First employee in the list:");
            employees[0].DisplayInfo();

            // Check if employee with ID = 10 exists
            Console.WriteLine("\nChecking if employee with ID = 10 exists...");

            bool exists = employees.Any(e => e.ID == 10);

            if (exists)
            {
                Console.WriteLine("Employee with ID 10 exists in the list.");
            }
            else
            {
                Console.WriteLine("Employee with ID 10 does NOT exist.");
            }

            /*Exercise 3: Dictionary Operations 
            • Create a Dictionary<string, Employee> where the key is the employee's full name. 
            • Iterate through the dictionary and display all keys(names). 
            • Remove an employee from the dictionary by their name and verify the removal.*/

            // Create Dictionary<string, Employee>
            Console.WriteLine("\nCreating Dictionary (Key = Full Name)...");

            Dictionary<string, Employee> employeeByName =
                new Dictionary<string, Employee>();

            foreach (var emp in employees)
            {
                string fullName = $"{emp.FirstName} {emp.LastName}";
                employeeByName[fullName] = emp;   // safer than Add()
            }

            Console.WriteLine($"Dictionary contains {employeeByName.Count} employees.");


            // Iterate and display all keys (names)
            Console.WriteLine("\nEmployee Names in Dictionary:");

            foreach (var key in employeeByName.Keys)
            {
                Console.WriteLine(key);
            }


            // Remove employee by name and verify removal
            Console.WriteLine("\nRemoving employee by name...");

            string nameToRemove = "Ahmed Ali";

            bool removed = employeeByName.Remove(nameToRemove);

            if (removed)
            {
                Console.WriteLine($"{nameToRemove} removed successfully.");
            }
            else
            {
                Console.WriteLine($"{nameToRemove} not found in dictionary.");
            }

            Console.WriteLine("Dictionary count after removal: " + employeeByName.Count);

        }
    }
}