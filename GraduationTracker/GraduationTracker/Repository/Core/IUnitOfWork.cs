namespace GraduationTracker.Repository.Core
{
    public interface IUnitOfWork
    {
        IDiplomaRepository Diplomas { get; }
        IRequirementRepository Requirements { get; }
        IStudentRepository Students { get; }
    }
}
