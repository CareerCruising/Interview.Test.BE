using GraduationTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Repositories
{
    public class DiplomaRepository : IDiplomaRepository
    {
        public IEnumerable<Diploma> GetDiplomas()
        {
            return new List<Diploma>() {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] { 100, 102, 103, 104 }
                }
            };
        }

        public Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            return diplomas.ToList().FirstOrDefault(diploma => diploma.Id == id);
        }
    }
}
