using System;

namespace GraduationTracker
{
    public interface IGraduationStandingRetriever
    {
        Tuple<bool, STANDING> getGraduationStatusStanding();
    }
}
