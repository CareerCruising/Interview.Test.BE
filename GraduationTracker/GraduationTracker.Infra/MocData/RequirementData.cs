using GraduationTracker.Domain.Entities;
using GraduationTracker.Infra.Repositories;
using System.Collections.Generic;

namespace GraduationTracker.Infra.MocData
{
    public static class RequirementData
    {
        public static List<Requirement> GetRequirements()
        {
            var _courseRepository = new CourseRepository();
            
            return new List<Requirement>
            {
                    new Requirement{Id = 100, Course = _courseRepository.GetById(1), Credits=1 },
                    new Requirement{Id = 102, Course = _courseRepository.GetById(2), Credits=1 },
                    new Requirement{Id = 103, Course = _courseRepository.GetById(3), Credits=1 },
                    new Requirement{Id = 104, Course = _courseRepository.GetById(4), Credits=1 }
                };
        }
    }
}
