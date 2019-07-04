using GraduationTracker.Domain.Interfaces.Repositories;

namespace GraduationTracker.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
