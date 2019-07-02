using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Contract.DataContract;

namespace GraduationTracker.Repositories
{
    class DiplomaRepository : IDiplomaRepository // Separate Repository for Diplomas data
    {
        readonly IEnumerable<Diploma> diplomas = null;
        public DiplomaRepository()
        {
            diplomas = GetDiplomas();

        }

        public Diploma GetDiploma(int id)
        {
            //replaced for loops with lambda expression (much cleaner code)    
            return diplomas.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Diploma> GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new Requirement[] { new Requirement { Id = 100 }, new Requirement { Id = 102 }, new Requirement { Id = 103 }, new Requirement { Id = 104 }
                    }
                }
            };
        }

    }
}
