using System;
/// <summary>
/// GraduationTracker.cs file
/// </summary>
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
        /// <returns>bool, STANDING, bool</returns>
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
                    // Obtain & set requirement
                    var requirement = Repository.GetRequirement(req);
                    // Loop thru each requirement
                    foreach (var reqCourse in requirement.Courses)
                    {
                        // If required course doesn't equal ID
                        if (reqCourse != course.Id)
                        {
                            // Continue thru code
                            continue;
                        }
                        // Avg definition/calculation
                        average += course.Mark;

                        // If the course mark is greater than the minimal mark required
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

            // Logic for return (result) based on avg
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

            // Return tuple
            return result;
        }
    }
}
