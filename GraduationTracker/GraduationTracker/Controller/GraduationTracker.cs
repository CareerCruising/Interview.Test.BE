using GraduationTracker.IGraduationTrackerServices;
using GraduationTracker.Model;
using GraduationTracker.Model.Enum;
using System;
using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private IRepositoryServices _Repository = new RepositoryServicesController();
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            if (student.Courses.Any(x => x.Mark < 0 || x.Mark > 100))
                return new Tuple<bool, STANDING>(false, STANDING.None);
           
            var credits = 0;
            var average = 0;

            foreach (int req in diploma.Requirements)
            {
                foreach (Course course in student.Courses)
                {
                    var requirement = _Repository.GetRequirementByID(req);

                    int mark = requirement.Courses.Where(x => x == course.Id).Select(x => course.Mark).FirstOrDefault();
                    average += mark;
                    
                    if (course.Mark > requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                }
            }

            average = average / student.Courses.Length;

            var standing = STANDING.None;

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
                case STANDING.SumaCumLaude:
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }
    }
}
