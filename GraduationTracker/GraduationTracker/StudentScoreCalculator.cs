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
            var credits = 0;
            float totalMarks = 0;

            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                for (int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = this._requirementDAO.GetItemById(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            totalMarks += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
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
