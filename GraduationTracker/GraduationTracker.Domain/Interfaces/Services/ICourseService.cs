using GraduationTracker.Domain.Entities;
using System.Collections.Generic;

namespace GraduationTracker.Domain.Interfaces.Services
{
    public interface ICourseService : IBaseService<Course> 
    {
        Course GetById(int id);
        IEnumerable<Course> GetAll();
    }
}
