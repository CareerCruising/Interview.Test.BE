using System;
using GraduationTracker.Models;

namespace GraduationTracker.Repositories
{
    public class DiplomaRepository : IRepository<Diploma>
    {
        public Diploma GetById(int id)
        {
            var diplomas = GetDiplomas();
            var result = Array.Find(diplomas, (diploma => diploma.Id == id));
            return result;
        }

        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new []{100,102,103,104}
                }
            };
        }
    }
}