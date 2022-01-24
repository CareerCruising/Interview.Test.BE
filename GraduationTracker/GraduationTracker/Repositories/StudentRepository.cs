using GraduationTracker.Data;
using GraduationTracker.Models.Interfaces;
using System.Linq;

namespace GraduationTracker.Repositories
{
    public class StudentRepository
    {
        public static SeedingData seedingData = new SeedingData();
        public static IStudent GetStudent(int Id)
        {
            var students = seedingData.GetStudents();

            return students.FirstOrDefault(x => x.Id == Id);
        }
        public static IStudentCourse[] GetStudentCoursesByStudentId(int Id)
        {
            return seedingData.GetStudentCourses().Where(x => x.Student == Id).ToArray();
        }
    }
}
