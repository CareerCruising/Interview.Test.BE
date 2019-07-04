using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Domain.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _repository.GetAll();
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
                return _repository.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
        }
    }
}
