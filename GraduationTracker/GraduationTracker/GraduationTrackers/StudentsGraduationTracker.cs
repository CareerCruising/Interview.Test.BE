
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Diplomas;
using GraduationTracker.Students;

namespace GraduationTracker.GraduationTrackers
{
    public partial class StudentsGraduationTracker
    {
        private IDiploma diploma;
        private IEnumerable<IStudent> students;

        public StudentsGraduationTracker(IEnumerable<IStudent> students, IDiploma diploma)
        {
            this.diploma = diploma;
            this.students = students;
        }


        public IEnumerable<IStudent> GetStudentsFailedInMath()
        {
            return from student in this.students
                   where student.CoursesMark.Any(cm => cm.Name == "Math" && cm.Mark < this.diploma.GetRequirementByCourseId(cm.Id).MinimumMark)
                   select student;
        }

        public IEnumerable<IStudent> GetStudentsApprovedInScience()
        {
            return from student in this.students
                   where student.CoursesMark.Any(cm => cm.Name == "Science" && cm.Mark > this.diploma.GetRequirementByCourseId(cm.Id).MinimumMark)
                   select student;
        }
    }
}
