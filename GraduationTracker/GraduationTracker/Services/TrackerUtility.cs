using GraduationTracker.ENUMS;

namespace GraduationTracker.Services
{
    public class TrackerUtility
    {
        public STANDING GetSTANDING(float average)
        {
            if (average < 50)
                return STANDING.Remedial;
            else if (average < 80)
                return STANDING.Average;
            else if (average < 95)
                return STANDING.MagnaCumLaude;
            else
                return STANDING.SumaCumLaude;
        }
    }
}
