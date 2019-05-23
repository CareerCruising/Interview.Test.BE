using System;

namespace GraduationTracker
{
    // Removed Partial keyword below as based on current files in the project there is no significance of Partial Keyword.
    public class GraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            // There is no need of credits variable in this method as we are not using it to calculate student graduation eligibility.
            //var credits = 0; 
            var average = 0;

            for (var i = 0; i < diploma.Requirements.Length; i++)
            {
                for (var j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    if (requirement.CourseId != student.Courses[j].Id) continue;
                    average += student.Courses[j].Mark;
                    break;

                    // Commented below For Loop as each Requirement has only one CourseId in Repository. Also we are not using credits in this method to calculate student graduation eligibility.

                    //for (var k = 0; k < requirement.Courses.Length; k++)
                    //{
                    //    if (requirement.Courses[k] == student.Courses[j].Id)
                    //    {
                    //        average += student.Courses[j].Mark;
                    //        //if (student.Courses[j].Mark > requirement.MinimumMark)
                    //        //{
                    //        //    credits += requirement.Credits;
                    //        //}
                    //    }
                    //}
                }
            }

            average = average / student.Courses.Length;

            STANDING standing;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }
    }
}
