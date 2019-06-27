using System;

namespace GraduationTracker
{
    /// <summary>
    /// Graduation Tracker Class
    /// </summary>
    public class GraduationTracker
    {
        /// <summary>
        /// Determines if a student has graduated based on standing, avg & credits earned
        /// </summary>
        /// <param name="diploma"></param>
        /// <param name="student"></param>
        /// <returns>Tuple, Bool, STANDING</returns>
        public Tuple<bool, STANDING, bool>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            // Replaced nested for loops w/ foreach loops (cleaner code)
            foreach (var req in diploma.Requirements)
            {
                // Loop thru each course
                foreach (var course in student.Courses)
                {
                    var requirement = Repository.GetRequirement(req);
                    // Loop thru each requirement
                    foreach (var reqCourse in requirement.Courses)
                    {
                        if (reqCourse != course.Id)
                        {
                            continue;
                        }
                        // Calculate avg
                        average += course.Mark;
                        if (course.Mark > requirement.MinimumMark)
                        {
                            // Tally credits
                            credits += requirement.Credits;
                            // Update credits
                            course.Credits = credits;
                        }
                    }
                }
            }

            // HasCredits
            var hasCredits = credits >= diploma.Credits;
            // Average calculation
            average = average / student.Courses.Length;

            // var standing = STANDING.None;

            // Define result
            Tuple<bool, STANDING, bool> result;

            // Logic for return
            if (average < 50)
            {
                result = new Tuple<bool, STANDING, bool>(false, STANDING.Remedial, hasCredits);
            }
            else if (average < 80)
            {
                result = new Tuple<bool, STANDING, bool>(true, STANDING.Average, hasCredits);
            }
            else if (average < 95)
            {
                result = new Tuple<bool, STANDING, bool>(true, STANDING.MagnaCumLaude, hasCredits);
            }
            else
            {
                result = new Tuple<bool, STANDING, bool>(true, STANDING.SumaCumLaude, hasCredits);
            }

            return result;
        }
    }
}
