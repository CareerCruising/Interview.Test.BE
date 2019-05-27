using GraduationTracker.BLL;
using GraduationTracker.DML;
using System;
using System.Linq;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        /// <summary>
        /// Check if the Student has been graduated
        /// </summary>
        /// <param name="diploma">Diploma to match with student courses</param>
        /// <param name="student">Student information</param>
        /// <returns>Tuple informing has graduated/Standing/Credits</returns>
        public Tuple<bool, STANDING, int> HasGraduated(Diploma diploma, Student student)
        {
            bool graduated = false;
            int credits = 0;
            var average = 0;

            foreach (Requirement iDipReq in diploma.Requirements)
            {
                //Get the diploma's requirement
                Requirement reqCourse = BRequirement.GetRequirement(iDipReq.Id);

                foreach (Course iStuCou in student.Courses)
                {
                    //Check if the current student course belongs to the diploma's requirement course
                    if (reqCourse.Courses.SingleOrDefault(x => x.Id == iStuCou.Id) != null)
                    {
                        average += iStuCou.Mark;

                        if (iStuCou.Mark > reqCourse.MinimumMark)
                            credits += reqCourse.Credits;
                    }
                }
            }

            average = average / student.Courses.Count;

            var standing = STANDING.None;

            if (average < 50)
            {
                standing = STANDING.Remedial;
                graduated = false;
            }
            else if (average < 80)
            {
                standing = STANDING.Average;
                graduated = true;
            }
            else if (average < 95)
            {
                standing = STANDING.MagnaCumLaude;
                graduated = true;
            }
            else
            {
                standing = STANDING.MagnaCumLaude;
                graduated = true;
            }

            return new Tuple<bool, STANDING, int>(graduated, standing, credits);
             
        }
    }
}
