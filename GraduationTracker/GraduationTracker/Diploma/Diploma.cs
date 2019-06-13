

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Diploma:BaseClass,ICredits
    {
        public int Credits { get; set; }
        public RequirementCourses[] Requirements { get; set; }
    }
}
