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

            foreach (var vRequirement in diploma.Requirements)
            {
                var requirement = Repository.GetRequirement(vRequirement);

                foreach (var sCourse in student.Courses)
                {
                    foreach (var rCourse in requirement.Courses)
                    {
                        if (rCourse == sCourse.Id)
                        {
                            average += sCourse.Mark;
                            if (sCourse.Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }                       
                    }

                }
            }

            average = average / student.Courses.Count;

            var standing = STANDING.None;
            bool bItem = false;
            if (average < 50)
            {
                bItem = false;
                standing = STANDING.Remedial;
            }
            else if (average < 80)
            {
                bItem = true; 
                standing = STANDING.Average;
            }
            else if (average < 95)
            {
                bItem = true; 
                standing = STANDING.MagnaCumLaude;
            }
            else
            {
                bItem = true;
                standing = STANDING.MagnaCumLaude;
            }

            return new Tuple<bool, STANDING>(bItem, standing);
        }
    }
}
