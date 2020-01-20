using System;
using System.Linq;

namespace GraduationTracker
{
    public class GraduationTracker
    {   
        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student)
        {
            if (diploma == null) throw new ArgumentException("Invalid diploma.");
            if (student == null) throw new ArgumentException("Invalid student.");

            var credits = 0;
            var average = 0;
            var requirements = GetDiplomaRequirements(diploma);

            foreach (var requirement in requirements)
            {
                foreach (var courseId in requirement.Courses)
                {
                    var course = student.Courses.FirstOrDefault(studentCourse => studentCourse.Id == courseId);
                    if (course == null) return new Tuple<bool, Standing>(false, Standing.None);

                    average += course.Mark;
                    if (course.Mark > requirement.MinimumMark)
                        credits += requirement.Credits;
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

        private Requirement[] GetDiplomaRequirements(Diploma diploma) 
        {
            return Repository.GetRequirements()
                .Where(requirement => diploma.Requirements.Contains(requirement.Id))
                .ToArray();
        }
    }
}
