using GraduationTracker.Domain.Interfaces.Services;

namespace GraduationTracker.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
    }
}
