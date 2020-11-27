using System;

namespace GraduationTracker
{
    public abstract class RepositoryFactoryBase
    {
        public static string RepositoryFactoryName;

        public static string RepositoryFactoryNamespace;

        public static Lazy<RepositoryFactoryBase> Instance; 

        static RepositoryFactoryBase()
        {
            RepositoryFactoryName = "RepositoryFactory";
            RepositoryFactoryNamespace = "GraduationTracker";

            Instance = GetLazyRepositoryFactory();
        }

        protected RepositoryFactoryBase()
        {

        }

        public abstract CourseRepository CreateCourseRepository();

        public abstract DiplomaRepository CreateDiplomaRepository();

        public abstract DiplomaRequirementRepository CreateDiplomaRequirementRepository();

        public abstract RequirementCourseRepository CreateRequirementCourseRepository();

        public abstract RequirementRepository CreateRequirementRepository();

        public abstract StudentCourseRepository CreateStudentCourseRepository();

        public abstract StudentRepository CreateStudentRepository(Diploma diploma);

        private static Lazy<RepositoryFactoryBase> GetLazyRepositoryFactory()
        {
            Type repositoryFactoryType = Type.GetType(string.Format("{1}.{0}, {1}", RepositoryFactoryName, RepositoryFactoryNamespace));
            
            return new Lazy<RepositoryFactoryBase>(() => (RepositoryFactoryBase) Activator.CreateInstance(repositoryFactoryType));
        }
        public static void Refresh()
        {
            Instance = GetLazyRepositoryFactory();
        }
    }
}
