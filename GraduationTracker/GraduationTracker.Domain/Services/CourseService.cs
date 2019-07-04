using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> GetAll()
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

        public Course GetById(int id)
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
