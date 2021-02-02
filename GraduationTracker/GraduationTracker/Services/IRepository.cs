using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Services
{
    public interface IRepository
    {
        Student[] GetAllStudents();
        Diploma[] GetAllDiplomas();
        Requirement[] GetAllRequirements();
        Student GetStudentById(int id);
        Diploma GetDiplomaById(int id);
        Requirement GetRequirementById(int id);
    }
}
