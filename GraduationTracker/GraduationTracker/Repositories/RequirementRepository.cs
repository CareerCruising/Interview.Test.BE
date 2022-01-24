using GraduationTracker.Data;
using GraduationTracker.Models.Interfaces;
using System.Linq;

namespace GraduationTracker.Repositories
{
    public class RequirementRepository
    {
        public static SeedingData seedingData = new SeedingData();

        public static IRequirement GetRequirementById(int id)
        {
            var diplomas = seedingData.GetRequirements();

            return diplomas.FirstOrDefault(x => x.Id == id);
        }
    }
}
