using System.Collections.Generic;

namespace GraduationTracker.Interfaces
{
    public interface IDatabase
    {
        List<Student> Students { get; }
        List<Diploma> Diplomas { get; }
        List<Requirement> Requirements { get; }
    }
}
