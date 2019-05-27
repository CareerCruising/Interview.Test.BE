using GraduationTracker.DAL;
using GraduationTracker.DML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.BLL
{
    public class BStudent
    {
        /// <summary>
        /// Get Student details by Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Return Student object filled data by Id</returns>
        public static Student GetStudent(int id)
        {
            try
            {
                return DStudent.GetStudent(id);
            }
            catch (Exception e)
            {
                BLog.Error("An error has occured on get Student: " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Get List of Student
        /// </summary>
        /// <returns>Return List of Student encountered</returns>
        private static List<Student> GetStudents()
        {
            return DStudent.GetStudents();
        }
    }
}
