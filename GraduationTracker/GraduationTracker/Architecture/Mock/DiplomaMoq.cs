using System.Collections.Generic;
using GraduationTracker.Architecture.Domain.Modules;

namespace GraduationTracker.Architecture.Mock
{
    public class DiplomaMoq
    {
        public static IEnumerable<Diploma> GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new Requirement[]
                    {
                        new Requirement { Id = 100 },
                        new Requirement { Id = 102 },
                        new Requirement { Id = 103 },
                        new Requirement { Id = 104 }
                    }
                }
            };
        }
    }
}
