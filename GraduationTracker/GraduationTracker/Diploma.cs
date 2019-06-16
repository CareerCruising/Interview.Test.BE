using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    /// <summary>
    /// This class represents a diploma.
    /// </summary>
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }
    }
}