using GraduationTracker.Diplomas;
using GraduationTracker.Students;

namespace GraduationTracker.GraduationTrackers
{
    
    public partial class StudentGraduationTracker
    {
        private IDiploma diploma;
        private IStudent student;

        public StudentGraduationTracker(IStudent student, IDiploma diploma)
        {
            this.diploma = diploma;
            this.student = student;

        }

        public ResultGraduationTracker StudentHasGraduated()
        {
            var totalCredit = this.student.GetTotalCredit(this.diploma);
            var avaregeMark = this.student.GetAvarageMark();
            var standing = this.student.GerStudentStatanding(avaregeMark);
            var isGraduated = this.student.IsGraduated(standing);
            return new ResultGraduationTracker
            {
                IsGraduated = isGraduated,
                Credits = totalCredit,
                Standing = standing
            };
        }
    }
}
