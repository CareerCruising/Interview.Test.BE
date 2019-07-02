using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Common
{
    public class Common //Class for all common functions
    {

        public static STANDING GetStandingBasedOnAverageMarks(int avgMarks)
        {
            var standing = STANDING.None;

            if (avgMarks < 50)
                standing = STANDING.Remedial;
            else if (avgMarks < 80)
                standing = STANDING.Average;
            else if (avgMarks < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;
            return standing;
        }

        public static bool IsGraduatedBasedOnStanding(STANDING standing)
        {
            bool IsGraduated = false;
            if ((standing == STANDING.Average) || (standing == STANDING.SumaCumLaude) || (standing == STANDING.MagnaCumLaude))
            {
                IsGraduated = true;
            }
            else
            {
                IsGraduated = false;
            }

            return IsGraduated;

        }
    }
}
