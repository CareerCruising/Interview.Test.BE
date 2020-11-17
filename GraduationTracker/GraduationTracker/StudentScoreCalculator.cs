namespace GraduationTracker
{
    /// <summary>
    /// This class exhibits Single Responsibility of calculating Score for the given Diploma & Student data
    /// </summary>
    public class StudentScoreCalculator
    {
        RequirementDAO _requirementDAO;
        public StudentScoreCalculator(RequirementDAO requirementDAO)
        {
            this._requirementDAO = requirementDAO;
        }

        public float GetAverageMarks(Diploma diploma, Student student)
        {
            var credits = 0; //unused variable

            float totalMarks = 0;
            int noOfDiplomaReq = diploma.Requirements.Length;
            int noOfStudentCourses = student.Courses.Length;
            int noOfReqCourses;

            for (int diplomaReqIdx = 0; diplomaReqIdx < noOfDiplomaReq; diplomaReqIdx++)
            {
                var requirement = this._requirementDAO.GetItemById(diploma.Requirements[diplomaReqIdx]);
                noOfReqCourses = requirement.Courses.Length;
                for (int stdntCourseIdx = 0; stdntCourseIdx < noOfStudentCourses; stdntCourseIdx++)
                {
                    for (int reqCourseIdx = 0; reqCourseIdx < noOfReqCourses; reqCourseIdx++)
                    {
                        if (requirement.Courses[reqCourseIdx] == student.Courses[stdntCourseIdx].Id)
                        {
                            totalMarks += student.Courses[stdntCourseIdx].Mark;
                            if (student.Courses[stdntCourseIdx].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            return totalMarks / student.Courses.Length;
        }
    }
}
