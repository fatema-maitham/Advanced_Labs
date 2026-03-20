using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab2._2_DatabaseFirst.Models;

[PrimaryKey("StudentId", "CourseId")]
public partial class Enrollment
{
    [Key]
    public int StudentId { get; set; }

    [Key]
    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    [StringLength(5)]
    public string? Grade { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student Student { get; set; } = null!;
}
