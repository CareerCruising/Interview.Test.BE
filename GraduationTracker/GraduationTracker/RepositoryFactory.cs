using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class RepositoryFactory : RepositoryFactoryBase
    {
        public RepositoryFactory() : base()
        {

        }

        public override CourseRepository CreateCourseRepository()
        {
            return new CourseRepository();
        }

        public override DiplomaRepository CreateDiplomaRepository()
        {
            return new DiplomaRepository();
        }

        public override DiplomaRequirementRepository CreateDiplomaRequirementRepository()
        {
            return new DiplomaRequirementRepository();
        }

        public override RequirementCourseRepository CreateRequirementCourseRepository()
        {
            return new RequirementCourseRepository();
        }

        public override RequirementRepository CreateRequirementRepository()
        {
            return new RequirementRepository();
        }

        public override StudentCourseRepository CreateStudentCourseRepository()
        {
            return new StudentCourseRepository();
        }

        public override StudentRepository CreateStudentRepository(Diploma diploma)
        {
            return new StudentRepository(diploma);
        }
    }
}
