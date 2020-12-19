using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.IGraduationTrackerServices
{
    public interface IRepositoryServices
    {
        Student GetStudent(int id);
        Diploma GetDiplomaByID(int id);
        Requirement GetRequirementByID(int id);
    }
}
