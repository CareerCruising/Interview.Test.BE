using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class Requirement
    {
        protected RequirementRepository requirementRepository;
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; protected set; }
        internal IEnumerable<RequirementCourse> Courses { get; set; }

        public Requirement(int id)
        {
            this.Id = id;
            RequirementCourseRepository requirementCourseRepository = RepositoryFactoryBase.Instance.Value.CreateRequirementCourseRepository();
            this.Courses = requirementCourseRepository.GetRequirementCourses(this.Id);

            this.requirementRepository = new RequirementRepository();
        }

        public bool IsCoursePartOfRequirement(int courseId)
        {
            return this.Courses.Any(c => c.CourseId == courseId);
        }

        public bool AreCourseRequirementsMet(IEnumerable<StudentCourse> studentCourses)
        {
            IEnumerable<Course> requiredCourses = this.requirementRepository.GetCoursesByRequirement(this.Id);
            IDictionary<Course, bool> courseRequirementFufilled = requiredCourses.ToDictionary(rc => rc, rc => false);
            StudentCourse tempStudentCourse;

            foreach(Course rf in requiredCourses)
            {
                tempStudentCourse = studentCourses.SingleOrDefault(sc => sc.CourseId == rf.Id);
                
                if (tempStudentCourse != null)
                    courseRequirementFufilled[rf] = tempStudentCourse.IsCoursePassed(this.MinimumMark);
            }

            return !courseRequirementFufilled.Any(crf => crf.Value == false);
        }

        public int GetCredits()
        {
            CourseRepository courseRepository = RepositoryFactoryBase.Instance.Value.CreateCourseRepository();
            Course tempCourse;

            foreach (RequirementCourse requirementCourse in this.Courses)
            {
                tempCourse = courseRepository.GetCourse(requirementCourse.CourseId);
                this.Credits += tempCourse.Credits;
            }

            return this.Credits;
        }
    }
}
