namespace GraduationTracker.GraduationTrackers
{
    public class ResultGraduationTracker
    {
        public ResultGraduationTracker()
        {
        }

        public bool IsGraduated { get; set; }
        public decimal Credits { get; set; }
        public Standing Standing { get; set; }
    }
}