using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
    public class StudentRepository
    {
        protected Diploma Diploma { get; set; }

        public StudentRepository(Diploma diploma)
        {
            this.Diploma = diploma;
        }

        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int id)
        {
            IEnumerable<Student> students = this.GetStudent();

            return students.SingleOrDefault(s => s.Id == id);
        }

        public virtual IEnumerable<Student> GetStudent()
        {
            return new[]
            {
               new Student(this.Diploma, 1),
               new Student(this.Diploma, 2),
               new Student(this.Diploma, 3),
               new Student(this.Diploma, 4)
            };
        }
    }
}
