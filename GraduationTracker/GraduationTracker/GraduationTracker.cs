using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
	public partial class GraduationTracker
	{
		/// <summary>
		/// Given a specific Diploma and a Student, determine the graduation status of the Student.
		/// </summary>
		/// <returns>
		/// A tuple:
		///	<list type="bullet">
		///	<item><see cref="Tuple{T1,T2}.Item1"/>: Whether or not Student has graduated.</item>
		///	<item><see cref="Tuple{T1,T2}.Item2"/>: What kind of Standing the Student has.</item>
		///	</list>
		/// </returns>
		public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
		{
			if (student.Courses == null || student.Courses.Length == 0)
			{
				return Tuple.Create(false, STANDING.None);
			}
			var credits = 0;
			var totalMarks = 0;
			var courseCount = 0;

			// Get all diploma requirements
			var diplomaRequirements = diploma.Requirements
				.Select(id => Repository.GetRequirement(id));

			foreach (var requirement in diplomaRequirements)
			{
				var relevantCourses = GetRelevantCourses(student, requirement);
				totalMarks += relevantCourses.Select(c => c.Mark).Sum();
				courseCount += relevantCourses.Count();
				// Only courses that meet the requirement's minimum mark count towards credit.
				if (relevantCourses.Any(c => c.Mark > requirement.MinimumMark))
				{
					credits += requirement.Credits;
				}
			}

			var average = totalMarks / courseCount;
			return Tuple.Create(CanGraduate(diploma, credits), CalculateStanding(average));
		}

		/// <summary>
		/// Extracts the relevant courses a student has taken that the specified Requirement requires.
		/// </summary>
		private IEnumerable<Course> GetRelevantCourses(Student student, Requirement requirement)
		{
			return student.Courses.Where(c => requirement.Courses.Contains(c.Id));
		}

		/// <summary>
		/// Given the specified Diploma, whether or not the accumulated credits is sufficient for graduation.
		/// </summary>
		private bool CanGraduate(Diploma diploma, int totalCredits)
		{
			return totalCredits >= diploma.Credits;
		}

		/// <summary>
		/// Given a Student's course average, determine the student's Standing
		/// </summary>
		private STANDING CalculateStanding(double average)
		{
			if (average < 50)
				return STANDING.Remedial;
			else if (average < 80)
				return STANDING.Average;
			else if (average < 95)
				return STANDING.MagnaCumLaude;
			else
				return STANDING.SumaCumLaude;
		}
	}
}
