using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Courses;

namespace GraduationTracker.Diplomas
{
    public class Diploma : IDiploma
    {
        public int Id { get; set; }
        public IEnumerable<IRequirement> Requirements { get; set; }

        public int GetCreditsByCourseMark(CourseMark courseMark)
        {
            IRequirement req = this.GetRequirementByCourseId(courseMark.Id);
            return (courseMark.Mark > req.MinimumMark) ? req.Credits : 0;
        }


        public IRequirement GetRequirementByCourseId(int courseId)
        {
            return this.Requirements.Where(req => req.Course.Id == courseId).FirstOrDefault();
        }

    }
}
