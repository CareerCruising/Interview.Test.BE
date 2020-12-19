using System.Linq;

namespace GraduationTracker.IGraduationTrackerServices
{
    public class RepositoryServicesController : IRepositoryServices
    {
        private IGraduationDBContextServices _IGraduationService = new GraduationDBServicesController();

        public Student GetStudent(int StudentID)    
        {
            var students = _IGraduationService.GetAllStudent();
            Student student = students.Where(x => x.Id == StudentID).FirstOrDefault();

            //Strong candidate to be removed once tested on server
            /*for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            */

            return student;
        }

        public Diploma GetDiplomaByID(int DiplomaID)
        {
            var diplomas = _IGraduationService.GetAllDiploma();
            Diploma diploma = diplomas.Where(x => x.Id == DiplomaID).FirstOrDefault();

            //Strong candidate to be removed once tested on server
            /*
            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }*/

            return diploma;
        }

        public Requirement GetRequirementByID(int RequirementID)
        {
            var requirements = _IGraduationService.GetAllRequirements();
            Requirement requirement = requirements.Where(x => x.Id == RequirementID).FirstOrDefault();

            //Strong candidate to be removed once tested on server
            /*
            for (int i = 0; i < requirements.Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }*/

            return requirement;
        }
    }
}
