using System;

namespace GraduationTracker
{
    /// <summary>
    /// Strategy pattern is used and individual classes for each STANDING values are created to avoid the switch statements
    /// </summary>
    public class StandingRemedial: IGraduationStandingRetriever
    {

        public Tuple<bool, STANDING> getGraduationStatusStanding()
        {
            return new Tuple<bool, STANDING>(false, STANDING.Remedial);
        }
    }
}
