using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;
using System;

namespace GraduationTracker.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public CourseRepository()
        {
        }

        public Course GetCourseByStudent(Student student, int id)
        {
            return Array.Find(student.Courses, element => element.Id == id);
        }
    }
}
