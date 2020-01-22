using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            var studentCourseMarks = Repository.GetStudentCourseMarks().Where(m => m.StudentId == student.Id).ToArray();

            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                for (int j = 0; j < studentCourseMarks.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == studentCourseMarks[j].CourseId)
                        {
                            average += studentCourseMarks[j].Mark;
                            if (studentCourseMarks[j].Mark > requirement.MinimumMark)
                            {
                                var course = Repository.GetCourse(requirement.Courses[k]);
                                credits += course.Credits;
                            }
                        }
                    }
                }
            }

            average = average / studentCourseMarks.Length;

            var earnedEnoughCredits = credits >= diploma.Credits;

            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(earnedEnoughCredits, standing);
                case STANDING.SummaCumLaude:
                    return new Tuple<bool, STANDING>(earnedEnoughCredits, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(earnedEnoughCredits, standing);
                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }
    }
}
