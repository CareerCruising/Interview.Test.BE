namespace GraduationTracker.Architecture.Domain.Modules.Repository
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Return data of student by code.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);
    }
}
