using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
  public class Course
  {
    [Key]
    public string CourseName { get; set; }
    public int CourseId { get; set; }

  }

  public class Student
  {
    public int StudentId { get; set; }
    public string StudentName { get; set; }
  }

  public class Enrollment
  {
    public int EnrollmentId { get; set; }
    public string Grade { get; set; }
    public Course Course { get; set; }
    public Student Student { get; set; }
  }
}
