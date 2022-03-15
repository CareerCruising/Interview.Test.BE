using System;
using System.Linq;

namespace GraduationTracker
{
    public sealed class GraduationTracker
    {
        IRepository Repository { get; }

        public GraduationTracker(IRepository repository) => Repository = repository;

        public GradutationStatus HasGraduated(Diploma diploma, Student student)
        {
            var requirements = Repository.GetRequirements(diploma.Requirements);

            var totalMarks = student.Courses.Where(c => 
                requirements!.SelectMany(static _ => _.Courses)
                    .Contains(c.Id)).Sum(static courses => courses.Mark);

            var credits = (from requirement in diploma.Requirements
                select requirements?.First(_ => _.Id == requirement)
                into req
                let studentMark = student.Courses.First(_ => req.Courses.Contains(_.Id)).Mark 
                where studentMark >= req.MinimumMark
                select req.Credits).Count();


            return new GradutationStatus(credits >= diploma.Credits, FindStanding());

            STANDING FindStanding() => (totalMarks / student.Courses.Length) switch
            {
                > 95 => STANDING.SumaCumLaude,
                > 80 => STANDING.Average,
                > 50 => STANDING.Remedial,
                _ => STANDING.None
            };
        }
    }
}
