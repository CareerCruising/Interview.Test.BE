using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Student.Standings Standing { get; set; }
        public decimal Average { get; set; }
        public int Credits { get; set; }
        public enum Standings { None, SumaCumLaude, MagnaCumLaude, Average, Remedial }
        public IEnumerable<StudentCourse> Courses { get; set; }

        protected Diploma diploma { get; set; }

        public Student(Diploma diploma, int id)
        {
            StudentCourseRepository studentCourseRepository = RepositoryFactoryBase.Instance.Value.CreateStudentCourseRepository();
            
            this.Id = id;
            this.Courses = studentCourseRepository.GetStudentCourse(this.Id);
            this.Standing = Student.Standings.None;
            this.diploma = diploma;
        }

        public int CourseCount { get { return this.Courses.Count(); } }

        public bool IsGraduated()
        {
            return this.diploma.AreRequirementsMet(this.Courses);
        }

        /// <summary>
        /// This method calculated the average of all courses student had taken disregarding the fact that 
        /// not every course will be part of the required course towards a acheiving a diploma
        /// </summary>
        /// <returns></returns>
        public decimal GetAverage()
        {
            int runningTotal = default(int);

            foreach (StudentCourse c in this.Courses)
                runningTotal += c.Mark;

            //have test if 2 int types can return a decimal
            this.Average = Convert.ToDecimal(runningTotal) / Convert.ToDecimal(this.Courses.Count());

            return this.Average;
        }

        /// <summary>
        /// This method gets the average of courses that is required within diploma
        /// </summary>
        /// <returns></returns>
        public decimal GetRequirementAverage()
        {
            int runningTotal = default(int);
            int count = default(int);

            foreach (StudentCourse c in this.Courses)
                if (this.diploma.IsCoursePartOfDiploma(c.CourseId))
                {
                    runningTotal += c.Mark;
                    count++;
                }

            this.Average = Convert.ToDecimal(runningTotal) / Convert.ToDecimal(count);

            return this.Average;
        }

        public int GetCredits()
        {
            RequirementRepository requirementRepository = RepositoryFactoryBase.Instance.Value.CreateRequirementRepository();
            Requirement tempRequirement;

            foreach (DiplomaRequirement diplomaRequirement in this.diploma.Requirements)
            {
                tempRequirement = requirementRepository.GetRequirement(diplomaRequirement.RequirementId);

                if (tempRequirement.AreCourseRequirementsMet(this.Courses))
                    this.Credits += tempRequirement.GetCredits();
            }
                
            return this.Credits;
        }

        public Student.Standings GetStandings()
        {
            if (this.Average == default(int))
                throw new System.Exception("Average has to be calculated first");

            if (this.Average < 50m && this.Average >= 0m)
                this.Standing = Student.Standings.Remedial;
            else if (this.Average < 80m && this.Average >= 50m)
                this.Standing = Student.Standings.Average;
            else if (this.Average < 95m && this.Average >= 80m)
                this.Standing = Student.Standings.MagnaCumLaude;
            else
                this.Standing = Student.Standings.SumaCumLaude;

            return this.Standing;
        }
    }
}
