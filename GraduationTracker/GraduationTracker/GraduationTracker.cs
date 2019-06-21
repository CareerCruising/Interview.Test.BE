using System;
using System.Linq;
using GraduationTracker.Abstraction;
using GraduationTracker.Models;

namespace GraduationTracker
{
    public class GraduationTracker
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IRequirementsRepository _requirementsRepository;
        private readonly IDiplomasRepository _diplomasRepository;

        public GraduationTracker(IStudentsRepository studentsRepository, IRequirementsRepository requirementsRepository, IDiplomasRepository diplomasRepository)
        {
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
            _requirementsRepository = requirementsRepository ?? throw new ArgumentNullException(nameof(requirementsRepository));
            _diplomasRepository = diplomasRepository ?? throw new ArgumentNullException(nameof(diplomasRepository));
        }

        public Tuple<bool, Standing> HasGraduated(int diplomaId, int studentId)
        {
            var diploma = _diplomasRepository.GetDiploma(diplomaId) ??
                          throw new InvalidOperationException($"Diploma with ID {diplomaId} does not exist");

            var student = _studentsRepository.GetStudent(studentId) ??
                          throw new InvalidOperationException($"Student with ID {diplomaId} does not exist");

            //TODO: reconsider business requirements and use this variable somewhere
            var credits = 0;
            var total = 0;

            foreach (var requirementId in diploma.Requirements)
            {
                var requirement = _requirementsRepository.GetRequirement(requirementId) ??
                                  throw new InvalidOperationException($"Requirement with ID {requirementId} does not exist");

                foreach (var course in student.Courses.Where(x => requirement.Courses.Contains(x.Id)))
                {
                    total += course.Mark;
                    if (course.Mark > requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                }
            }

            var average = total / student.Courses.Length;

            Standing standing;

            if (average < 50)
                standing = Standing.Remedial;
            else if (average < 80)
                standing = Standing.Average;
            else
                standing = Standing.MagnaCumLaude;

            switch (standing)
            {
                case Standing.Average:
                case Standing.SummaCumLaude:
                case Standing.MagnaCumLaude:
                    return new Tuple<bool, Standing>(true, standing);
                default:
                    return new Tuple<bool, Standing>(false, standing);
            }
        }
    }
}