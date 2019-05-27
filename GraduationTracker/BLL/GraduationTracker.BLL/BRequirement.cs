using GraduationTracker.DAL;
using GraduationTracker.DML;
using System;
using System.Collections.Generic;

namespace GraduationTracker.BLL
{
    public class BRequirement
    {
        /// <summary>
        /// Get Requirement details by Id
        /// </summary>
        /// <param name="id">Requirement Id</param>
        /// <returns>Return Requirement object filled data by Id</returns>
        public static Requirement GetRequirement(int id)
        {
            try
            {
                return DRequirement.GetRequirement(id);
            }
            catch (Exception e)
            {
                BLog.Error("An error has occured on get Requirement: " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Get List of Requirement
        /// </summary>
        /// <returns>Return List of Requirement encountered</returns>
        public static List<Requirement> GetRequirements()
        {
            return DRequirement.GetRequirements();
        }
    }
}
