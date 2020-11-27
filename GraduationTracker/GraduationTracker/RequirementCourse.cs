using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class RequirementCourse
    {
        public int Id { get; set; }
        public int RequirementId { get; set; }
        public int CourseId { get; set; }

        public RequirementCourse()
        {

        }
    }
}
