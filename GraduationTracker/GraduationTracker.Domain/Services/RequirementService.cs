using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Services
{
    public class RequirementService : BaseService<Requirement>, IRequirementService
    {
        private readonly IRequirementRepository _repository;
        public RequirementService(IRequirementRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Requirement> GetAll()
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

        public Requirement GetById(int id)
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
