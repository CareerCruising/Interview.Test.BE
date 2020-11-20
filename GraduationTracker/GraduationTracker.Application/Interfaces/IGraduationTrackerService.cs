using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Models;

namespace GraduationTracker.Application.Interfaces
{
    public interface IGraduationTrackerService
    {
        int GetAverage(Diploma diploma, Student student);
        bool IsPassed(int average);
        STANDING GetStanding(int average);

        int GetCredits(int[] requirements, Student student);
    }
}
