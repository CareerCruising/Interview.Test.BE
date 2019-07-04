using System;

namespace GraduationTracker.Domain.Entities
{
    public class Requirement
    {
        private readonly int MinMarkValue = 50;

        public int Id { get; set; }
        public int MinimumMark { get { return MinMarkValue; } }
        public int Credits { get; set; }
        public Course Course { get; set; }
        public bool Valid { get { return ValidadeCredits(); } }

        private bool ValidadeCredits()
            => this.Course.Mark >= MinimumMark;
    }
}
