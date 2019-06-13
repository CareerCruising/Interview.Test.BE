
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Requirement:BaseClass,ICredits
    {
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
    }
}
