namespace GraduationTracker
{
    public sealed class GradutationStatus
    {
        public bool HasDiplomaCreditCount { get; }
        public STANDING Standing { get; }

        public GradutationStatus(bool hasDiplomaCreditCount, STANDING standing)
        {
            HasDiplomaCreditCount = hasDiplomaCreditCount;
            Standing = standing;
        }
    }
}