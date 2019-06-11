namespace GraduationTracker
{
    public abstract class Requirement : Base, ICredits
    {
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
    }
}
