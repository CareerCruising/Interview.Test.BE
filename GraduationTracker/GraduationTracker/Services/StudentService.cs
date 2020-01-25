using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Services
{
    public class StudentService : IStudentService
    {
        private Student _student { get; set; }
        public Student Student => _student;

        public StudentService(Student student)
        {
            _student = student;
        }

        /// <summary>
        /// Gets the student standing based on current marks acquired in courses
        /// </summary>
        /// <returns>Standing flag</returns>
        public Standing GetStanding()
        {
            var totalMarks = 0;
            Array.ForEach(_student.Courses, (course) => { totalMarks += course.Mark; });
            var average = totalMarks / _student.Courses.Length;
            _student.Standing = average < 50 ? Standing.Remedial
                             : average < 80 ? Standing.Average
                             : average < 95 ? Standing.MagnaCumLaude
                             : Standing.SumaCumLaude;

            return _student.Standing;
        }

        /// <summary>
        /// Gets total acquired credits by student till now.
        /// </summary>
        /// <param name="requirements"></param>
        /// <returns>Total acquired credits</returns>
        public int CalculateCredits(IEnumerable<Requirement> requirements)
        {
            var credits = 0;
            foreach (var course in _student.Courses)
            {
                /*
                   Note: Based on the assumption that each course can have only one requirement
                   otherwise their could be unexpected behaviour while calculating credits.
                */

                var courseRequirement = requirements.FirstOrDefault((requirement) =>
                     requirement.Courses.Contains(course.Id));

                if (courseRequirement != null && course.Mark > courseRequirement.MinimumMark)
                {
                    credits += courseRequirement.Credits ;
                }
            }
            return credits;
        }
    }
}
