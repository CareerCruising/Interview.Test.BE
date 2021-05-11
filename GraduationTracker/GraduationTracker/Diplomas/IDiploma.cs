using System.Collections.Generic;
using GraduationTracker.Courses;

namespace GraduationTracker.Diplomas
{
    public interface IDiploma
    {
        int Id { get; set; }
        IEnumerable<IRequirement> Requirements { get; set; }

        int GetCreditsByCourseMark(CourseMark courseMark);
        IRequirement GetRequirementByCourseId(int courseId);
    }
}