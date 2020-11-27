using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class RequirementCourseRepository
    {
        public RequirementCourseRepository()
        { 
        
        }

        public void Add(RequirementCourse requirementCourse)
        {
            throw new NotImplementedException();
        }

        public void Update(RequirementCourse requirementCourse)
        {
            throw new NotImplementedException();
        }

        public void Delete(int requirementId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequirementCourse> GetRequirementCourses(int requirementId)
        {
            IEnumerable<RequirementCourse> requirementCourse = this.GetRequirementCourse();

            return requirementCourse.Where(sc => sc.RequirementId == requirementId);
        }

        public RequirementCourse GetRequirementCourse(int id)
        {
            IEnumerable<RequirementCourse> requirementCourses = this.GetRequirementCourse();

            return requirementCourses.SingleOrDefault(rc => rc.Id == id);
        }

        public virtual IEnumerable<RequirementCourse> GetRequirementCourse()
        {
            return new List<RequirementCourse>()
            {
                new RequirementCourse { Id = 1, RequirementId = 100, CourseId = 1 },
                new RequirementCourse { Id = 2, RequirementId = 102, CourseId = 2 },
                new RequirementCourse { Id = 3, RequirementId = 103, CourseId = 3 },
                new RequirementCourse { Id = 4, RequirementId = 104, CourseId = 4 },
            };
        }
    }
}
