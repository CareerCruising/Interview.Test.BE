using GraduationTracker.DAL;
using GraduationTracker.DML;
using System;
using System.Collections.Generic;

namespace GraduationTracker.BLL
{
    public class BDiploma
    {
        /// <summary>
        /// Get Diploma details by Id
        /// </summary>
        /// <param name="id">Diploma Id</param>
        /// <returns>Return Diploma object filled data by Id</returns>
        public static Diploma GetDiploma(int id)
        {
            try
            {
                return DDiploma.GetDiploma(id);
            }
            catch (Exception e)
            {
                BLog.Error("An error has occured on get Diploma: " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Get List of Diploma
        /// </summary>
        /// <returns>Return List of Diploma encountered</returns>
        private static List<Diploma> GetDiplomas()
        {
            return DDiploma.GetDiplomas();
        }
    }
}
