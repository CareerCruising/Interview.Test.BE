using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Contract.DataContract
{
    public interface IDiplomaRepository
    {
        Diploma GetDiploma(int id);
        IEnumerable<Diploma> GetDiplomas();
    }
}
