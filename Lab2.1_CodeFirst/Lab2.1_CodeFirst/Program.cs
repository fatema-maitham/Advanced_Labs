using Lab2._1_CodeFirst.Data;
using Lab2._1_CodeFirst.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using System.Numerics;

using var context = new AppDbContext();
context.Students.RemoveRange(context.Students);
context.Courses.RemoveRange(context.Courses);
context.SaveChanges();
// Only add data if the Students table is empty 
if (!context.Students.Any())
{
    Console.WriteLine("Adding new students to the database...");
    context.Students.Add(new Student
    {
        FirstName = "Ali",
        LastName = "Hassan",
        Email = "alihassan@bpoly.bh",
        EnrollmentDate = new DateTime(2025, 9, 1)
    });


    context.Students.Add(new Student
    {
        FirstName = "Mohsen",
        LastName = "Ali",
        Email = "mohsen.ali@bpoly.bh",
        EnrollmentDate = new DateTime(2025, 9, 1)
    });

    context.Students.Add(new Student
    {
        FirstName = "Sayed hassan",
        LastName = "Sayed Mohamed",
        Email = "sayedhassanmohamed@bpoly.bh",
        EnrollmentDate = new DateTime(2024, 9, 1)
    });

    context.SaveChanges();
}
else
{
    Console.WriteLine("Database already contains student records. Skipping inserts."); 
}



int added=context.SaveChanges();
Console.WriteLine($"{added} student(s) added successfully.");

// Adding courses 
Console.WriteLine("\nAdding courses to the database...");

context.Courses.Add(new Course
{
    Title = "Advanced Programming",
    Description = "Web development with .NET 9, EF Core, and ASP.NET MVC",
    Credits = 3
});

context.Courses.Add(new Course
{
    Title = "Database Systems",
    Description = "Relational database design and SQL",
    Credits = 3
});

int coursesAdded = context.SaveChanges();

Console.WriteLine($"{coursesAdded} course(s) added successfully.");


// Read all students 
Console.WriteLine("\n--- All Students ---");

var allStudents = context.Students.ToList();

foreach (var student in allStudents)
{
    Console.WriteLine($"[{student.Id}] {student.FirstName} {student.LastName} - {student.Email} ");
}


// Find by primary key 
Console.WriteLine("\n--- Find Student by ID ---");

var student1 = context.Students.Find(1);

if (student1 != null)
{
    Console.WriteLine($"Found: {student1.FirstName} {student1.LastName}");
}
else
{
    Console.WriteLine("Student not found.");
}

// LNQ query - filter by enrollment year
Console.WriteLine("\n-- Students Enrolled in 2025 ---");
var students2025 = context.Students
    .Where(s=> s.EnrollmentDate.Year == 2025)
    .OrderBy(s=> s.LastName)
    .ToList();


foreach(var student in students2025)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - Enrolled: {student.EnrollmentDate:d}");
}

Console.WriteLine("\n--- Updating Student ---");

var studentToUpdate = context.Students.Find(1);

if (studentToUpdate != null)
{
    Console.WriteLine($"Before: {studentToUpdate.Email}");

    studentToUpdate.Email = "ali.h@bpoly.bh";
    context.SaveChanges();

    Console.WriteLine($"After:  {studentToUpdate.Email}");
    Console.WriteLine("Student updated successfully.");
}


// Delete a student 
Console.WriteLine("\n--- Deleting Student ---");

var studentToDelete = context.Students.Find(3);

if (studentToDelete != null)
{
    Console.WriteLine($"Deleting: {studentToDelete.FirstName} { studentToDelete.LastName}"); 


    context.Students.Remove(studentToDelete);
    context.SaveChanges();

    Console.WriteLine("Student deleted successfully.");
}

// Verify deletion 
Console.WriteLine("\n--- Remaining Students ---");

var remaining = context.Students.ToList();

foreach (var s in remaining)
{
    Console.WriteLine($"[{s.Id}] {s.FirstName} {s.LastName}");
}

//Lab Exercises 
/*Complete the following exercises to reinforce the concepts covered in this lab. 
Exercise 1: Extend the Model 
• Add a new entity class called Instructor with properties: Id, FirstName, LastName,
Department, and HireDate. 
• Add a DbSet<Instructor> property to the AppDbContext. 
• Run Add-Migration AddInstructor and Update-Database to update the database. 
• Verify the new table in SQL Server Object Explorer. 
• Add at least 3 Instructor records and display them in the console.*/

// Add instructors
Console.WriteLine("\nAdding instructors to the database...");

context.Instructors.Add(new Instructor
{
    FirstName = "Ahmed",
    LastName = "Saleh",
    Department = "Computer Science",
    HireDate = new DateTime(2020, 5, 15)
});

context.Instructors.Add(new Instructor
{
    FirstName = "Zainab",
    LastName = "Hassan",
    Department = "Information Systems",
    HireDate = new DateTime(2022, 3, 10)
});

context.Instructors.Add(new Instructor
{
    FirstName = "Sayed Mahdi",
    LastName = "Ali",
    Department = "Software Engineering",
    HireDate = new DateTime(2021, 8, 1)
});

int instructorsAdded = context.SaveChanges();
Console.WriteLine($"{instructorsAdded} instructor(s) added successfully.");


Console.WriteLine("\n--- All Instructors ---");
var allInstructors = context.Instructors.ToList();

foreach (var instructor in allInstructors)
{
    Console.WriteLine($"[{instructor.Id}] {instructor.FirstName} {instructor.LastName} - {instructor.Department}, Hired: {instructor.HireDate:d}");
}



/*Exercise 2: Advanced Queries 
• Write a LINQ query to find all courses with more than 2 credits. 
• Write a LINQ query to count the total number of students enrolled in 2025. 
• Use FirstOrDefault() to find a student by email address and display their details. Handle 
the case where the email does not exist.*/

// 1. Find all courses with more than 2 credits
Console.WriteLine("\n--- Courses with more than 2 credits ---");
var highCreditCourses = context
    .Courses.Where(c=> c.Credits >2)
    .ToList();

foreach (var course in highCreditCourses)
{
    Console.WriteLine($"{course.Title} - {course.Credits} credits");
}

// Count the total number of students enrolled in 2025
Console.WriteLine("\n--- Count of students enrolled in 2025 ---");
int count2025= context.Students.Count(s => s.EnrollmentDate.Year == 2025);
Console.WriteLine($"Total students enrolled in 2025: {count2025}");

// Find a student by email using FirstOrDefault()
Console.WriteLine("\n--- Find Student by Email ---");

Console.Write("Enter student email: ");
string searchEmail = Console.ReadLine() ?? ""; 

var studentByEmail = context.Students
    .FirstOrDefault(s => s.Email == searchEmail);

if (studentByEmail != null)
{
    Console.WriteLine($"Found: {studentByEmail.FirstName} {studentByEmail.LastName} - {studentByEmail.Email}");
}
else
{
    Console.WriteLine($"No student found with email: {searchEmail}");
}

/*
 * Exercise 3: Full CRUD on Courses 
• Add 3 more courses to the database with different credit values. 
• Update the description of an existing course. 
• Delete a course by its Id. 
• Display all remaining courses sorted by title. 
 */

//Add 3 more courses
Console.WriteLine("\n--- Adding More Courses ---");

context.Courses.Add(new Course
{
    Title = "Operating Systems",
    Description = "Processes, threads, scheduling, and memory management",
    Credits = 4
});

context.Courses.Add(new Course
{
    Title = "Computer Networks",
    Description = "TCP/IP, routing, switching, and network protocols",
    Credits = 3
});

context.Courses.Add(new Course
{
    Title = "Artificial Intelligence",
    Description = "Machine learning, search algorithms, and expert systems",
    Credits = 5
});

int moreCoursesAdded = context.SaveChanges();
Console.WriteLine($"{moreCoursesAdded} course(s) added successfully.");



Console.WriteLine("\n--- Updating Course Description ---");

var courseToUpdate = context.Courses.FirstOrDefault(c => c.Title == "Database Systems");

if (courseToUpdate != null)
{
    Console.WriteLine($"Before: {courseToUpdate.Description}");
    courseToUpdate.Description = "Advanced relational database design, SQL optimization, and transactions";
    context.SaveChanges();
    Console.WriteLine($"After: {courseToUpdate.Description}");
    Console.WriteLine("Course updated successfully.");
}
else
{
    Console.WriteLine("Course not found.");
}

Console.WriteLine("\n--- Deleting Course ---");

int deleteId = 2; // example: delete course with Id = 2
var courseToDelete = context.Courses.Find(deleteId);

if (courseToDelete != null)
{
    Console.WriteLine($"Deleting: {courseToDelete.Title}");
    context.Courses.Remove(courseToDelete);
    context.SaveChanges();
    Console.WriteLine("Course deleted successfully.");
}
else
{
    Console.WriteLine($"No course found with Id = {deleteId}");
}