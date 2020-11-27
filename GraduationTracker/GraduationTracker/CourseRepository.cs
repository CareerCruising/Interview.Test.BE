using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class CourseRepository
    {
        public CourseRepository()
        {

        }

        public void Add(Course course)
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course GetCourse(int id)
        {
            IEnumerable<Course> courses = this.GetCourse();

            return courses.SingleOrDefault(c => c.Id == id);
        }

        public virtual IEnumerable<Course> GetCourse()
        {
            return new List<Course>()
            {
                new Course { Id = 1, Name = "Math", Credits = 1},
                new Course { Id = 2, Name = "Science", Credits = 1 },
                new Course { Id = 3, Name = "Literature", Credits = 1 },
                new Course { Id = 4, Name = "Physical Education", Credits = 1 }
            };
        }
    }
}
