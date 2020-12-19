using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.IGraduationTrackerServices
{
    interface IGraduationDBContextServices
    {
        Student[] GetAllStudent();
        Diploma[] GetAllDiploma();
        Requirement[] GetAllRequirements();
    }
}
