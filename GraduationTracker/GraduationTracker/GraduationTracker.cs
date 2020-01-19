using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, Standing>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;
        
            for(int i = 0; i < diploma.Requirements.Length; i++)
            {
                for(int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            average /= student.Courses.Length;

            if (average < 50)
                return new Tuple<bool, Standing>(false, Standing.Remedial);
            else if (average < 80)
                return new Tuple<bool, Standing>(true, Standing.Average);
            else if (average < 95)
                return new Tuple<bool, Standing>(true, Standing.MagnaCumLaude);
            else
                return new Tuple<bool, Standing>(true, Standing.SumaCumLaude);            
        }
    }
}
