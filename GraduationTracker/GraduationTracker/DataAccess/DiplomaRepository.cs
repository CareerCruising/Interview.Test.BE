using GraduationTracker.DataAccess;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public class DiplomaRepository : BaseRepository<Diploma>
    {
        protected override IEnumerable<Diploma> GetAll()
        {
            return new List<Diploma>()
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }
    }
}