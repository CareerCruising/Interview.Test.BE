namespace GraduationTracker.Repositories
{
    public interface IRepository<out T>
    {
        T GetById(int id);
    }
}