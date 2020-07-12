using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    {
            // CREATE operation
            Course Course = new Course();
            Course.CourseId = 6225;
            Course.CourseName = "ISM6225";

            Student Student = new Student();
            Student.StudentId = 9275;
            Student.StudentName = "Shawn McGinty";

            Enrollment Enrollment = new Enrollment();
            Enrollment.Course = Course;
            Enrollment.EnrollmentId = 3234;
            Enrollment.Student = Student;
            Enrollment.Grade = "A";

      dbContext.Courses.Add(Course);
      dbContext.Students.Add(Student);
      dbContext.Enrollments.Add(Enrollment);

      dbContext.SaveChanges();
      
      // READ operation
      Enrollment Enrollment1 = dbContext.Enrollments
                              .Where(e => e.EnrollmentId == 3234)
                              .First();

      Enrollment Enrollment2 = dbContext.Enrollments
                              .Include(e => e.Course)
                              .Where(e => e.Course.CourseId == Course.CourseId)
                              .First();

            // UPDATE operation
            Enrollment1.Course.CourseId = 6225;
            dbContext.Enrollments.Update(Enrollment1);
      //dbContext.SaveChanges();
      await dbContext.SaveChangesAsync();
      
      // DELETE operation
      //dbContext.Enrollments.Remove(Enrollment1);
      //await dbContext.SaveChangesAsync();

      return View();
    }

    //public ViewResult LINQOperations()
    //{
    //  Course Course1 = dbContext.Courses
    //         .Where(c => c.CourseName=="ISM6225")
    //         .First();

    //  Enrollment Enrollment1 = dbContext.Enrollments
    //         .Where(e => e.EnrollmentId == 3234)
    //         .First();

    //  Enrollment Enrollment2 = dbContext.Enrollments
    //         .Include(e => e.Course)
    //         .Where(e => e.Course.CourseId == Course1.CourseId)
    //         .First();

    //        Student Student1 = dbContext.Enrollments
    //              .Include(e => e.Student)
    //              .Where(e => e.Student = Student)
    //              .FirstOrDefault()
    //              .Students
    //              .FirstOrDefault();
     // return View();
    }

  }
