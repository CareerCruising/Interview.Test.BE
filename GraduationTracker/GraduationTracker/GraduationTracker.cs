using GraduationTracker.Application.Interfaces;
using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Models;
using System;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        private readonly IGraduationTrackerService _graduationTrackerService;

        public GraduationTracker(IGraduationTrackerService graduationTrackerService)
        {
            _graduationTrackerService = graduationTrackerService;
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            int average = _graduationTrackerService.GetAverage(diploma, student);

            var result = new Tuple<bool, STANDING>(_graduationTrackerService.IsPassed(average), 
                _graduationTrackerService.GetStanding(average));

            return result;
        }
    }
}
