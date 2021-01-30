using GraduationTracker.DBContext;
using GraduationTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Repository : IRepository
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public Student[] GetAllStudents()
        {
            return context.Students;
        }

        public Diploma[] GetAllDiplomas()
        {
            return context.Diplomas;
        }

        public Requirement[] GetAllRequirements()
        {
            return context.Requirements;
        }

        public Student GetStudentById(int id)
        {
            Student[] students = GetAllStudents();

            foreach (Student student in students)
            {
                if (id == student.Id)
                {
                    return student;
                }
            }

            return null;
        }

        public Diploma GetDiplomaById(int id)
        {
            Diploma[] diplomas = GetAllDiplomas();

            foreach (Diploma diploma in diplomas)
            {
                if (id == diploma.Id)
                {
                    return diploma;
                }
            }

            return null;
        }

        public Requirement GetRequirementById(int id)
        {
            Requirement[] requirements = GetAllRequirements();

            foreach (Requirement requirement in requirements)
            {
                if (id == requirement.Id)
                {
                    return requirement;
                }
            }

            return null;
        }
    }
}
