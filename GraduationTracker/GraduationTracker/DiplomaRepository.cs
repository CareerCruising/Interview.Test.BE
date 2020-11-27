using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class DiplomaRepository
    {
        public DiplomaRepository()
        {

        }
            
        public void Add(Diploma diploma)
        {
            throw new NotImplementedException();
        }

        public void Update(Diploma diploma)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Diploma GetDiploma(int id)
        {
            IEnumerable<Diploma> diplomas = this.GetDiploma();

            return diplomas.SingleOrDefault(d => d.Id == id);
        }

        public virtual IEnumerable<Diploma> GetDiploma()
        {
            return new[]
            {
                new Diploma(1)
            };
        }
    }
}
