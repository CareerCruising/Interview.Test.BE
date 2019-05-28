using GraduationTracker.DML;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.DAL
{
    public class DDiploma
    {
        /// <summary>
        /// Get Diploma details by Id
        /// </summary>
        /// <param name="id">Diploma Id</param>
        /// <returns>Return Diploma object filled data by Id</returns>
        public static Diploma GetDiploma(int id)
        {
            return GetDiplomas().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get List of Diploma
        /// </summary>
        /// <returns>Return List of Diploma encountered</returns>
        public static List<Diploma> GetDiplomas()
        {
            return new List<Diploma>
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new List<Requirement> {
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
