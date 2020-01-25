using GraduationTracker.Services;
using System;
using System.Collections.Generic;
using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit.FakeServices
{
    public class FakeStudentService : IStudentService
    {
        public Student Student => throw new NotImplementedException();

        private Standing _studentStanding;
        private int _credit;

        public FakeStudentService(Standing studentstanding, int studentCredit)
        {
            _studentStanding = studentstanding;
            _credit = studentCredit;
        }
        public int CalculateCredits(IEnumerable<Requirement> requirements)
        {
            return _credit;
        }

        public Standing GetStanding()
        {
            return _studentStanding;
        }
    }
}