using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;
            var includedCourseCount = 0;
            
            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                var requirement = Repository.GetRequirement(diploma.Requirements[i]);
                var passedCoursesCount = 0;
                for (int k = 0; k < requirement.Courses.Length; k++)
                {
                    for (int j = 0; j < student.Courses.Length; j++)
                    {                                        
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            includedCourseCount++;
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {                                
                                passedCoursesCount++;
                            }
                        }
                    }
                }
                if(passedCoursesCount == requirement.Courses.Length)
                {
                    credits += requirement.Credits;
                }
            }
            
            average = includedCourseCount == 0 ? 0 : average / includedCourseCount;

            var standing = STANDING.None;

            if (average == (int)STANDING.None)
                standing = STANDING.None;
            else if (average < (int)STANDING.Remedial)
                standing = STANDING.Remedial;
            else if (average < (int)STANDING.Average)
                standing = STANDING.Average;
            else if (average < (int)STANDING.MagnaCumLaude)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;

            if (credits < diploma.Credits) { return new Tuple<bool, STANDING>(false, standing); }

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
