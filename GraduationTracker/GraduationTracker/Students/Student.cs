using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Courses;
using GraduationTracker.Diplomas;

namespace GraduationTracker.Students
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public IEnumerable<CourseMark> CoursesMark { get; set; }


        public decimal GetAvarageMark()
        {
            int total = this.CoursesMark.Sum(cm => cm.Mark);
            return total / CoursesMark.Count();
        }

        public int GetTotalCredit(IDiploma diploma)
        {
            return this.CoursesMark.Select(cm => diploma.GetCreditsByCourseMark(cm)).Sum();
        }


        public Standing GerStudentStatanding(decimal avarageMark)
        {
            switch (avarageMark)
            {
                case < 50:
                    return Standing.Remedial;
                case < 80:
                    return Standing.Average;
                case < 90:
                    return Standing.MagnaCumLaude;
                default:
                    return Standing.SumaCumLaude;
            }
        }

        public bool IsGraduated(Standing standing)
        {
            return !(standing == Standing.Remedial || standing == Standing.None);
        }
    }
}
