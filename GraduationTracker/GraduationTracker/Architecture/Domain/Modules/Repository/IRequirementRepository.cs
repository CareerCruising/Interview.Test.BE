namespace GraduationTracker.Architecture.Domain.Modules.Repository
{
    public interface IRequirementRepository
    {
        /// <summary>
        ///     Return data of Requirement by code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Requirement GetRequirement(int id);
    }
}
