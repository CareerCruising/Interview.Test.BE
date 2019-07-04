using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Domain.Services
{
    public class DiplomaService : BaseService<Diploma>, IDiplomaService
    {
        private readonly IDiplomaRepository _repository;
        public DiplomaService(IDiplomaRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Diploma> GetAll()
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

        public Diploma GetById(int id)
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
