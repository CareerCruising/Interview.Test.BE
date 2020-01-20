namespace GraduationTracker.Repository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDiplomaRepository Diplomas { get; private set; }
        public IRequirementRepository Requirements { get; private set; }
        public IStudentRepository Students { get; private set; }

        public UnitOfWork()
        {
            Diplomas = new DiplomaRepository();
            Requirements = new RequirementRepository();
            Students = new StudentRepository();
        }
    }
}
