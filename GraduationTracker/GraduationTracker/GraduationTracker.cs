using GraduationTracker.Models.Interfaces;
using GraduationTracker.Repositories;
using GraduationTracker.Services;
using System.Linq;

namespace GraduationTracker
{
    public class GraduationTracker
    {   
        public bool HasGraduated(IDiploma diploma, IStudent student)
        {
            var trackerUtility = new TrackerUtility();
            var credits = 0;
            var average = 0f;
            //Adding the sum variable that represents the total marks of courses for a student. 
            var sum = 0f;
            var studentCourses = StudentRepository.GetStudentCoursesByStudentId(student.Id);
            foreach (var requirementId in diploma.Requirements)
            {
                var requirement = RequirementRepository.GetRequirementById(requirementId);
                
                var course = studentCourses.FirstOrDefault(x => x.Course == requirement.Course);

                //If student is missing a course from the requirement then return false
                if (course == null)
                {
                    return false;
                }

                sum += course.Mark;
                
                if (course.Mark >= requirement.MinimumMark)
                {
                    credits += requirement.Credits;
                }else
                {
                    return false;
                }
            }
            
            average = sum / studentCourses.Length;

            //In case if we need to get and use the student standing status
            var standing = trackerUtility.GetSTANDING(average);

            return average >= 50;

        }
    }
}
