using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationTracker.Contract;
using GraduationTracker.Contract.DataContract;

namespace GraduationTracker
{
    public partial class GraduationTracker : IGraduationTracker
    {
        private readonly IRequirementRepository _requirementRepository;
        private readonly IDiplomaRepository _diplomaRepository;
        private readonly IStudentRepository _studentRepository;

        public GraduationTracker(IRequirementRepository requirementRepository, IDiplomaRepository diplomaRepository, IStudentRepository studentRepository)
        {
            _requirementRepository = requirementRepository;
            _diplomaRepository = diplomaRepository;
            _studentRepository = studentRepository;

        }

        public Tuple<bool, STANDING, bool> HasGraduated(int diplomaId, int studentId)
        {

            var diploma = _diplomaRepository.GetDiploma(diplomaId);
            var student = _studentRepository.GetStudent(studentId);
            if (diploma == null || student == null)
            {
                throw new NullReferenceException("Invalid input paramaters");

            }

            var credits = 0;
            var average = 0;
            bool GotCredit = false;

            //replaced nested for loops with for each loops 
            foreach (var req in diploma.Requirements) //iterate through each requirement
            {
                foreach (var studCourse in student.Courses) //iterate through each course
                {
                    var requirement = _requirementRepository.GetRequirement(req.Id);

                    //Lambda expression used(much cleaner code), removed nested for loops, it will return null in case course id is not matched
                    var course = requirement.Courses.SingleOrDefault(x => x.Id == studCourse.Id);

                    if (course != null)
                    {
                        average += studCourse.Mark;
                        if (studCourse.Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }

                }

            }


            average = average / student.Courses.Count();


            GotCredit = (credits >= diploma.Credits) ? true : false;

            var standing = Common.Common.GetStandingBasedOnAverageMarks(average);
            bool IsGraduated = Common.Common.IsGraduatedBasedOnStanding(standing);

            return new Tuple<bool, STANDING, bool>(IsGraduated, standing, GotCredit);

        }

    }
}
