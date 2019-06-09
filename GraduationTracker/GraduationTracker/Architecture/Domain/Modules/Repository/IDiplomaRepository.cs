namespace GraduationTracker.Architecture.Domain.Modules.Repository
{
    public interface IDiplomaRepository
    {
        /// <summary>
        /// Return data of diploma by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Diploma GetDiploma(int id);
    }
}
