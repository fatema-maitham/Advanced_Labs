using Lab2._2_DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

using var context = new UniversityDbContext();

// List all students with their department name 
Console.WriteLine("--- Students and Departments ---");
var allStudents = context.Students
    .Include(s => s.Department)
    .ToList();

foreach (var s in allStudents)
{
    string deptName = s.Department?.Name ?? "No Department";
    Console.WriteLine($"{s.FirstName} {s.LastName} - {deptName}");
}

// List students in Computer Science department 
Console.WriteLine("\n--- Computer Science Students ---");

var csDept = context.Departments
    .Include(d => d.Students)
    .FirstOrDefault(d => d.Name == "Computer Science");

if (csDept != null)
{
    Console.WriteLine($"Department: {csDept.Name}");
    foreach (var student in csDept.Students)
    {
        Console.WriteLine($"  - {student.FirstName} {student.LastName}");
    }
}

// List courses for a specific student through enrollments 
Console.WriteLine("\n--- Courses for Ali Hassan ---");

var ali = context.Students
    .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
    .FirstOrDefault(s => s.FirstName == "Ali");

if (ali != null)
{
    foreach (var enrollment in ali.Enrollments)
    {
        Console.WriteLine($"  {enrollment.Course.Title}" +
            $" - Grade: {enrollment.Grade ?? "N/A"}" +
            $" - Enrolled: {enrollment.EnrollmentDate:d}");
    }
}

/*
Lab Exercises 
Complete the following exercises to reinforce the concepts covered in this lab. 
Exercise 1: Add an Instructors Table 
• Add a new Instructors table to the database with columns: Id (int, PK, Identity), FirstName 
(nvarchar(50)), LastName (nvarchar(50)), and DepartmentId (int, FK to Departments). 
• Add at least 3 instructor records with different departments. 
• Re-scaffold the project and verify the Instructor class was generated with the correct navigation 
properties. 
• Write a query in Program.cs to list all instructors grouped by department. 
Exercise 2: Query Across Multiple Relationships 
• Write a query that lists each department along with the count of students enrolled in it. 
• Write a query that finds the course with the most enrollments and displays the course title and 
number of students. 
• Write a query that lists all students who have a grade of "A" in any course, along with the course 
title. 
Exercise 3: Partial Class Extension 
• Create a new file called StudentExtensions.cs in the Models folder. 
• Add a partial Student class with a computed FullName property that returns "FirstName 
LastName". 
• Use the FullName property in Program.cs to display student names. 
• Re-scaffold the database and confirm that StudentExtensions.cs survives the regeneration. 
 */


// Exercise 1: Instructors grouped by department
var instructorsByDept = context.Instructors
    .GroupBy(i => i.DepartmentId)
    .Select(g => new { DepartmentId = g.Key, Instructors = g.ToList() })
    .ToList();

foreach (var dept in instructorsByDept)
{
    Console.WriteLine($"Department {dept.DepartmentId}:");
    foreach (var instructor in dept.Instructors)
    {
        Console.WriteLine($" - {instructor.FirstName} {instructor.LastName}");
    }
}

// Exercise 2: Queries across relationships
// 1. Departments with student counts
var studentCounts = context.Departments
    .Select(d => new
    {
        DepartmentName = d.Name,
        StudentCount = d.Students.Count()
    })
    .ToList();

foreach (var dept in studentCounts)
{
    Console.WriteLine($"{dept.DepartmentName}: {dept.StudentCount} students");
}

// 2. Course with most enrollments
var topCourse = context.Courses
    .Select(c => new
    {
        c.Title,
        EnrollmentCount = c.Enrollments.Count()
    })
    .OrderByDescending(c => c.EnrollmentCount)
    .FirstOrDefault();

Console.WriteLine($"Top course: {topCourse.Title} ({topCourse.EnrollmentCount} students)");

// 3. Students with grade "A"
var studentsWithA = context.Enrollments
    .Where(e => e.Grade == "A")
    .Select(e => new
    {
        StudentName = e.Student.FirstName + " " + e.Student.LastName,
        CourseTitle = e.Course.Title
    })
    .ToList();

foreach (var s in studentsWithA)
{
    Console.WriteLine($"{s.StudentName} - {s.CourseTitle}");
}

// Exercise 3: Partial class extension usage
var studentsList = context.Students.ToList();
foreach (var student in studentsList)
{
    Console.WriteLine(student.FullName);
}