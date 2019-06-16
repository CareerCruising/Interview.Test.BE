using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        /// <summary>
        /// Query and returns the requirement that matches with the given id.
        /// </summary>
        /// <param name="diploma">Diploma object.</param>
        /// <param name="student">Student object.</param>
        /// <returns>
        /// A Tuple<bool, STANDING> object that indicates if the student 
        /// graduated for that diploma and with which standing.
        /// </returns>
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            // Student's average mark
            var averageMark = 0;

            // For each diploma's requirement
            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                // For each student's course
                for(int j = 0; j < student.Courses.Length; j++)
                {
                    // Return the requirements for the diploma
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    // For each requirement's course
                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        // Check if the student took the required course
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            // Accumulate the student's mark for the required course
                            averageMark += student.Courses[j].Mark;

                            // Student accumulates the credits from that requirement 
                            // if student's mark is greater than requirement's
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                student.Courses[j].Credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            // Calculate the average based on total of courses taken
            averageMark = averageMark / student.Courses.Length;

            // Assign a standing based on the average
            var standing = STANDING.None;

            if (averageMark < 50)
                standing = STANDING.Remedial;
            else if (averageMark < 80)
                standing = STANDING.Average;
            else if (averageMark < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;

            // Return if got the diploma based on the standing
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
    }
}