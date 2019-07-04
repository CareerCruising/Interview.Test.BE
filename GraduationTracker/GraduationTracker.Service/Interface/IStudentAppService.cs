using GraduationTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationTracker.Service.Interface
{
    public interface IStudentAppService
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
