using System.Collections.Generic;
using GraduationTracker.Courses;
using GraduationTracker.Diplomas;

namespace GraduationTracker.Students
{
    public interface IStudent
    {
        int Id { get; set; }
        IEnumerable<CourseMark> CoursesMark { get; set; }

        Standing GerStudentStatanding(decimal avarageMark);
        decimal GetAvarageMark();
        int GetTotalCredit(IDiploma diploma);
        bool IsGraduated(Standing standing);
    }
}