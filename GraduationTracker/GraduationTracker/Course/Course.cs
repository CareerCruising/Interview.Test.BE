
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Course : BaseClass, ICredits
    {
        public int Credits { get; set; }
    }
}
