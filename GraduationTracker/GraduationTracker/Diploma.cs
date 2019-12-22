namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        // Unused. Is this the number of credits required to gain this diploma? If so, is that not already covered by the Requirements.Credits, or Requirements.Courses?
        public int Credits { get; set; }
        // References Requirement.Id
        public int[] Requirements { get; set; }
    }
}
