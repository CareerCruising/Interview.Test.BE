using System.Collections.Generic;
using GraduationTracker.Models;

namespace GraduationTracker.Services
{
    public interface IStudentService
    {
        Student Student { get; }
        Standing GetStanding();
        int CalculateCredits(IEnumerable<Requirement> requirements);
    }
}