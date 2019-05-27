namespace GraduationTracker.DAL
{
    public partial class DLog
    {
        /// <summary>
        /// Write the error message at log file
        /// </summary>
        /// <param name="messageLog">Message to write on log file</param>
        public static void Error(string messageLog)
        {
            //Proceed to save log
            System.IO.File.WriteAllText(@"c:\Error.txt", messageLog);
        }
    }
}
