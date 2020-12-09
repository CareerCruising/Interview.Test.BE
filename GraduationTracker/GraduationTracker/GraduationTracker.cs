using System;
using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            if (student.Courses.Any(x => x.Mark < 0))
                return null;
            if (student.Courses.Any(x => x.Credits < 0))
                return null;
            if (diploma.Credits < 0)
                return null;

            var credits = 0;
            var average = 0;

            foreach (var requirement in diploma.Requirements.Select(x => Repository.GetRequirement(x)))
            {
                foreach (var courseID in requirement.Courses)
                {
                    var mark = student.Courses
                        .Where(x => x.Id == courseID)
                        .Select(x => x.Mark)
                        .FirstOrDefault();
                    average += mark;

                    if (mark >= requirement.MinimumMark)
                        credits += requirement.Credits;
                }
            }

            if (credits < diploma.Credits)
                return new Tuple<bool, STANDING>(false, STANDING.None);

            switch(average /= student.Courses.Length)
            {
                case int n when n < 50:
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                case int n when n < 80:
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case int n when n < 95:
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
                default:
                    return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
            }
        }
    }
}
