using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Interfaces.Repositories;
using GraduationTracker.Infra.MocData;
using System.Collections.Generic;

namespace GraduationTracker.Infra.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public Course GetById(int id)
           => CourseData.GetAll().Find(s => s.Id == id);

        public IEnumerable<Course> GetAll()
            => CourseData.GetAll();
    }
}
