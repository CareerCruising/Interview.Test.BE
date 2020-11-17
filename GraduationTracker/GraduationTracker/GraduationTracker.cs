using GraduationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class GraduationTracker
    {
        IDatabase _database;
        public GraduationTracker()
        {
            this._database = new AppDatabase();
        }

        public GraduationTracker(IDatabase database)
        {
            this._database = database;
        }

        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            StudentScoreCalculator studentScoreCalculator = new StudentScoreCalculator(new RequirementDAO(this._database));
            var average = studentScoreCalculator.GetAverageMarks(diploma, student);
            IGraduationStandingRetriever standing = StandingFactory.GetStandingInstance(average);
            return standing.getGraduationStatusStanding();
        }
    }
}
