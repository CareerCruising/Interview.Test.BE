using System;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Architecture.Domain.Modules;
using GraduationTracker.Architecture.Domain.Modules.Enumerator;
using GraduationTracker.Architecture.Domain.Modules.Repository;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private IRequirementRepository RequirementRepository { get; set; }

        public GraduationTracker(IRequirementRepository requirementRepository)
        {
            RequirementRepository = requirementRepository;
        }

        public Tuple<bool, EnumStanding> HasGraduated(Diploma diploma, Student student)
        {
            var average = 0;
            var requirements = new List<Requirement>();
            diploma.Requirements.ToList().ForEach(x => requirements.Add(RequirementRepository.GetRequirement(x.Id)));

            student.Courses.ToList().ForEach(x =>
            {
                var requirement = requirements.SingleOrDefault(i => i.Courses.Count(z => z.Id == x.Id) > 0);
                if (requirement == null) return;
                average += x.Mark;
            });

            average = average / student.Courses.Count();

            var standing = GetStading(average);

            switch (standing)
            {
                case EnumStanding.Remedial:
                    return new Tuple<bool, EnumStanding>(false, standing);
                case EnumStanding.Average:
                    return new Tuple<bool, EnumStanding>(true, standing);
                case EnumStanding.SumaCumLaude:
                    return new Tuple<bool, EnumStanding>(true, standing);
                case EnumStanding.MagnaCumLaude:
                    return new Tuple<bool, EnumStanding>(true, standing);
                default:
                    return new Tuple<bool, EnumStanding>(false, standing);
            }
        }

        private EnumStanding GetStading(int average)
        {
            if (average < 50)
                return EnumStanding.Remedial;

            return average < 80 ? EnumStanding.Average : EnumStanding.MagnaCumLaude;
        }
    }
}
