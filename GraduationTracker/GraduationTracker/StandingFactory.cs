namespace GraduationTracker
{
    /// <summary>
    /// Factory design pattern is used to create the STANDING instance based on the average marks
    /// </summary>
    public class StandingFactory
    {
        public static IGraduationStandingRetriever GetStandingInstance(float averageMarks)
        {
            IGraduationStandingRetriever standingInstance;
            if (averageMarks < 50)
                standingInstance = new StandingRemedial();
            else if (averageMarks < 80)
                standingInstance = new StandingAverage();
            else if (averageMarks < 95)
                standingInstance = new StandingMagnaCumLaude();
            else
                standingInstance = new StandingSumaCumLaude();

            return standingInstance;
        }
    }
}
