using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;
using GraduationTracker.Infra.Data.Context;
using System;

namespace GraduationTracker.Infra.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StaticDataContext _ctx;

        public StudentRepository(StaticDataContext ctx)
        {
            _ctx = ctx;
        }

        public Student[] GetStudents()
        {
            return _ctx.Students;
        }

        public Student GetStudent(int id)
        {
            return Array.Find(_ctx.Students, element => element.Id == id);
        }
    }
}
