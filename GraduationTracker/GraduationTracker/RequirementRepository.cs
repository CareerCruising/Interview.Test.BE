using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class RequirementRepository
    {
        public RequirementRepository()
        {

        }

        public void Add(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        public void Update(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Requirement GetRequirement(int id)
        {
            IEnumerable<Requirement> requirements = this.GetRequirement();

            return requirements.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Course> GetCoursesByRequirement(int id)
        {
            Requirement requirement = this.GetRequirement().SingleOrDefault(r => r.Id == id);
            ICollection<Course> courses = new List<Course>();
            CourseRepository courseRepository = RepositoryFactoryBase.Instance.Value.CreateCourseRepository();

            foreach (RequirementCourse rc in requirement.Courses)
                courses.Add(courseRepository.GetCourse(rc.CourseId));

            return courses;
        }

        public virtual IEnumerable<Requirement> GetRequirement()
        {
            return new[]
            {
                new Requirement(100)
                {
                    Name = "Math",
                    MinimumMark = 50
                },
                new Requirement(102)
                {
                    Name = "Science",
                    MinimumMark = 50
                },
                new Requirement(103)
                {
                    Name = "Literature",
                    MinimumMark = 50
                },
                new Requirement(104)
                {
                    Name = "Physical Education",
                    MinimumMark = 50
                }
            };
        }
    }
}
