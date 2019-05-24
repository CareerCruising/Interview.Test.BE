using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public bool HasGraduated(Diploma diploma, Student student)
        {
            double totalMarks = 0;

            foreach (int requirementID in diploma.Requirements)
            {
                Requirement requirement = Repository.GetRequirement(requirementID);

                foreach (Course course in student.Courses)
                {
                    if (requirement.Courses.Contains(course.Id))
                    {
                        totalMarks += course.Mark;
                    }
                }
            }

            double averageMarks = totalMarks / student.Courses.Length;

            Standing standing = GetStanding(averageMarks);
            bool hasCredits = HasCredits(diploma, student);

            switch (standing)
            {
                case Standing.Remedial:
                    return false;
                case Standing.Average:
                    return hasCredits;
                case Standing.SumaCumLaude:
                    return hasCredits;
                case Standing.MagnaCumLaude:
                    return hasCredits;
                default:
                    return false;
            } 
        }

        public bool HasCredits(Diploma diploma, Student student)
        {
            int credits = 0;

            foreach (int requirementID in diploma.Requirements)
            {
                Requirement requirement = Repository.GetRequirement(requirementID);
                
                foreach (Course course in student.Courses)
                {
                    if (requirement.Courses.Contains(course.Id) && course.Mark >= requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                }
            }

            return credits >= diploma.Credits;
        }

        public Standing GetStanding(double average)
        {
            Standing currentStanding = Standing.None;
            if (average < 50)
                currentStanding = Standing.Remedial;
            else if (average < 80)
                currentStanding = Standing.Average;
            else if (average < 95)
                currentStanding = Standing.MagnaCumLaude;
            else
                currentStanding = Standing.SumaCumLaude;

            return currentStanding;
        }
    }
}
