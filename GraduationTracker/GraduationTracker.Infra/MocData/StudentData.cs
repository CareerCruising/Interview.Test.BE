using GraduationTracker.Domain.Entities;
using GraduationTracker.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Infra.MocData
{
    public static class StudentData
    {
        public static List<Student> GetStudents()
        {
            var _requirementRepository = new RequirementRepository();
            var requirements = _requirementRepository.GetAll();

            return new List<Student>()
            {
                new Student
                {
                   Id = 1,
                   Requirements = GiveMarks(requirements,95)
                },
               new Student
               {
                   Id = 2,
                   Requirements = GiveMarks(requirements,80)
               },
               new Student
               {
                    Id = 3,
                    Requirements = GiveMarks(requirements,50)
               },
                new Student
                {
                    Id = 4,
                    Requirements = GiveMarks(requirements,40)
                }
            };
        }

        private static List<Requirement> GiveMarks(IEnumerable<Requirement> Requirements, int Mark)
        {
            return Requirements.Select(r => new Requirement
            {
                Id = r.Id,
                Credits = r.Credits,
                Course = new Course { Id = r.Course.Id, Name = r.Course.Name, Mark = Mark }
            }).ToList();
        }
    }
}
