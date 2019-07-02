using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Contract
{
    public interface IGraduationTracker
    {
        Tuple<bool, STANDING, bool> HasGraduated(int diplomaId, int studentId);
    }
}
