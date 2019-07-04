using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Course GetById(int id);
        IEnumerable<Course> GetAll();
    }
}
