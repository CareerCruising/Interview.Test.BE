using GraduationTracker.DAL;

namespace GraduationTracker.BLL
{
    public partial class BLog
    {
        /// <summary>
        /// Write the error message at log file
        /// </summary>
        /// <param name="messageLog">Message to write on log file</param>
        public static void Error(string messageLog)
        {
            //Proceed to save log
            DLog.Error(messageLog);
        }
    }
}
