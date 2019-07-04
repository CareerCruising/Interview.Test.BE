using GraduationTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Domain.Interfaces.Services
{
    public interface IRequirementService : IBaseService<Requirement>
    {
        Requirement GetById(int id);
        IEnumerable<Requirement> GetAll();
    }
}
