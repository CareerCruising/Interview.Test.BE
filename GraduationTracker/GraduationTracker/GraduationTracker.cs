using System;
using GraduationTracker.Models;

namespace GraduationTracker
{
    public class GraduationTracker
    {
        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student)
        {
            //TODO: reconsider business logic and use this variable somewhere
            var credits = 0;
            var average = 0;

            for (var i = 0; i < diploma.Requirements.Length; i++)
            {
                for (var j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (var k = 0; k < requirement.Courses.Length; k++)
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

            Standing standing;

            if (average < 50)
                standing = Standing.Remedial;
            else if (average < 80)
                standing = Standing.Average;
            else
                standing = Standing.MagnaCumLaude;

            switch (standing)
            {
                case Standing.Average:
                case Standing.SummaCumLaude:
                case Standing.MagnaCumLaude:
                    return new Tuple<bool, Standing>(true, standing);
                default:
                    return new Tuple<bool, Standing>(false, standing);
            }
        }
    }
}