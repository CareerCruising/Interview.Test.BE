
namespace GraduationTracker.Models.Interfaces
{
    public interface IRequirement : IBaseModel
    {
        int Course { get; }
        float MinimumMark { get; }
        int Credits { get; }
    }
}
