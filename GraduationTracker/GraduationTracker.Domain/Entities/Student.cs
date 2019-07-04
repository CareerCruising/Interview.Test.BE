using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Domain.Entities
{
    public class Student
    {
        private const int MinMark = 50;
        public int Id { get; set; }
        public List<Requirement> Requirements { get; set; }
        public bool Graduated { get { return HasGraduated(); } }
        public STANDING Standing { get { return GetSTANDING(); } }// = STANDING.None;
        public int Avegare { get { return CalculateAverage(); } }

        private bool HasGraduated()
            => Avegare >= MinMark;

        private STANDING GetSTANDING()
        {
            if (Avegare < 50)
                return STANDING.Remedial;
            else if (Avegare < 80)
                return STANDING.Average;
            else if (Avegare < 95)
                return STANDING.SumaCumLaude;
            else
                return STANDING.MagnaCumLaude;
        }

        private int CalculateAverage()
            => Convert.ToInt32(Requirements.Select(c => c.Course.Mark).Average());
    }
}
