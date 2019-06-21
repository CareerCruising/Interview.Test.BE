using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Abstraction;
using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public class DiplomasRepository : IDiplomasRepository
    {
        public Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            return diplomas.FirstOrDefault(x => x.Id == id);
        }

        private List<Diploma> GetDiplomas()
        {
            return new List<Diploma>
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] {100, 102, 103, 104}
                }
            };
        }
    }
}