using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Services;
using GraduationTracker.Service.Interface;
using System;
using System.Collections.Generic;

namespace GraduationTracker.Service
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService)
            => _studentService = studentService;

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _studentService.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }

        public Student GetById(int id)
        {
            try
            {
                return _studentService.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }
    }
}
