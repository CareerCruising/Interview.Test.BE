using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private readonly Repository repository = new Repository();

        public Student GetStudent(int id)
        {
            return repository.GetStudent(id);
        }

        public Diploma GetDiploma(int id)
        {
            return repository.GetDiploma(id);
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            // variables
            int average = 0;
            bool isFailedAnyCourse = false;

            // validations
            if (diploma == null ||
                diploma.Requirements == null)
            {
                throw new Exception("Invalid diploma");
            }

            if (student == null ||
                student.Courses == null)
            {
                throw new Exception("Invalid student");
            }

            // check if one is qualified for graduation
            foreach (int req in diploma.Requirements)
            {
                Requirement requirement = repository.GetRequirement(req);

                // validation
                if (requirement == null)
                {
                    throw new Exception("Incorrect requirement id " + req);
                }

                // get averages and check if the one failed any courses
                bool isCourseFound = false;

                foreach (int reqCourse in requirement.Courses)
                {
                    foreach (Course course in student.Courses)
                    {
                        if (reqCourse == course.Id)
                        {
                            isCourseFound = true;
                            average += course.Mark;

                            if (course.Mark < requirement.MinimumMark)
                            {
                                isFailedAnyCourse = true;
                            }

                            break;
                        }
                    }

                    if (isCourseFound)
                    {
                        break;
                    }
                }

                if (!isCourseFound)
                {
                    throw new Exception(String.Format("Course not found for a student id {0}", student.Id));
                }
            }

            // calculate course average
            average /= student.Courses.Length;

            // get standing
            STANDING standing = GetStanding(average);

            // if failed any course, return false
            if (isFailedAnyCourse)
            {
                return new Tuple<bool, STANDING>(false, standing);
            }

            // return result based on the standing value
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

        private STANDING GetStanding(int average)
        {
            STANDING standing;

            if (average < 50)
            {
                standing = STANDING.Remedial;
            }
            else if (average < 80)
            {
                standing = STANDING.Average;
            }
            else if (average < 95)
            {
                standing = STANDING.MagnaCumLaude;
            }
            else
            {
                standing = STANDING.SumaCumLaude;
            }

            return standing;
        }
    }
}
