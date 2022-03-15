using System.Collections.Generic;

namespace GraduationTracker
{
    public interface IRepository
    {
        Student GetStudent(int id);
        Diploma GetDiploma(int id);
        Requirement GetRequirement(int id);
        IReadOnlyList<Requirement> GetRequirements(int[] ids);
        Diploma[] GetDiplomas();
        Requirement[] GetRequirements();
        Student[] GetStudents();
    }
}