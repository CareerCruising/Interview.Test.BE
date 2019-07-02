using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public IEnumerable<Requirement> Requirements { get; set; }
        //Replaced int[] type for Requirements with IEnumerable<Requirement>
    }
}
