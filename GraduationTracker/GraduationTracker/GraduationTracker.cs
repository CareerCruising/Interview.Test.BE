using System;

namespace GraduationTracker
{
    /// <summary>
    /// The Graduation Tracker 
    /// </summary>
    public class GraduationTracker
    {
        /// <summary>
        /// Compute the average, course creadits for a given student
        /// </summary>
        /// <param name="diploma">The diploma object.</param>
        /// <param name="student">the student object.</param>
        /// <returns>
        /// A Tuple&lt;bool, STANDING&gt; which indicates if the student
        /// has graduates, the standing and the credits achieved
        /// </returns>
        public Tuple<bool, Standing, bool>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;
        
            //diploma requirement
            foreach (var req in diploma.Requirements)
            {
                //student's course
                foreach (var course in student.Courses)
                {
                    //diploma requirement
                    var requirement = Repository.GetRequirement(req);
                    //courses requirement
                    foreach (var reqCourse in requirement.Courses)
                    {
                        if (reqCourse != course.Id) continue;
                        average += course.Mark;
                        if (course.Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                            course.Credits = credits;
                        }
                    }
                }
            }

            var hasCredits = credits >= diploma.Credits;
            average = average / student.Courses.Length;

            Tuple<bool, Standing, bool> result;

            if (average < 50)
                result = new Tuple<bool, Standing, bool>(false, Standing.Remedial, hasCredits);
            else if (average < 80)
                result = new Tuple<bool, Standing, bool>(true, Standing.Average, hasCredits);
            else if (average < 95)
                result = new Tuple<bool, Standing, bool>(true, Standing.MagnaCumLaude, hasCredits);
            else
                result = new Tuple<bool, Standing, bool>(true, Standing.SumaCumLaude, hasCredits);

            return result;
        }
    }
}
