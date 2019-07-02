using System;
using GraduationTracker.Models;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        /// <summary>
        /// Evaluates whether a <paramref name="student"/> has satisfied
        /// the requirements of <paramref name="diploma"/>
        /// </summary>
        /// <param name="diploma"></param>
        /// <param name="student"></param>
        /// <param name="standing">One of <see cref="GraduationTracker.Standing"/></param>
        /// <returns></returns>
        public bool HasGraduated(Diploma diploma, Student student, out STANDING standing)
        {
            standing = STANDING.None;
            var credits = 0;
            var average = 0m;

            if (student.Courses.Length <= 0)
                return false;
        
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

            average = Decimal.Divide(average, student.Courses.Length);

            if (average < 50m)
                standing = STANDING.Remedial;
            else if (average < 80m)
                standing = STANDING.Average;
            else if (average < 95m)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;

            return credits >= diploma.Credits;
        }
    }
}
