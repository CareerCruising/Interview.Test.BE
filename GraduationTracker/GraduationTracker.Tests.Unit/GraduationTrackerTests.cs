using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
		[TestMethod]
		public void StudentsWithNoCoursesShouldHaveNoStanding()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var studentA = new Student
			{
				Id = 1,
				Courses = new Course[] { }
			};
			var studentB = new Student
			{
				Id = 1,
				Courses = null
			};
			var students = new Student[] { studentA, studentB };
			foreach (var student in students)
			{
				var results = tracker.HasGraduated(diploma, student);
				Assert.IsFalse(results.Item1);
				Assert.AreEqual(results.Item2, STANDING.None);
			}
		}
		[TestMethod]
		public void StudentsWithoutSufficientCreditsDoNotGraduate()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var studentA = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 95 }
				}
			};
			var studentB = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 0 },
					new Course { Id = 2, Name = "Science", Mark = 95 },
					new Course { Id = 3, Name = "Literature", Mark = 95 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 95 },
				}
			};
			var studentC = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 95 },
					new Course { Id = 2, Name = "Science", Mark = 95 },
					new Course { Id = 3, Name = "Literature", Mark = 95 },
					new Course { Id = 5, Name = "Pottery", Mark = 95 },
				}
			};
			var students = new Student[] { studentA, studentB, studentC };
			foreach (var student in students)
			{
				var results = tracker.HasGraduated(diploma, student);
				Assert.IsFalse(results.Item1);
			}
        }

		[TestMethod]
		public void StudentsWithAnAverageBelowFiftyHaveRemedialStanding()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var student = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 49 },
					new Course { Id = 2, Name = "Science", Mark = 49 },
					new Course { Id = 3, Name = "Literature", Mark = 49 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 49 }
				}
			};
			var results = tracker.HasGraduated(diploma, student);
			Assert.AreEqual(results.Item2, STANDING.Remedial);
		}
		[TestMethod]
		public void StudentsWithAnAverageBetween50And80HaveAverageStanding()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var studentA = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 50 },
					new Course { Id = 2, Name = "Science", Mark = 50 },
					new Course { Id = 3, Name = "Literature", Mark = 50 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 50 }
				}
			};
			var studentB = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 79 },
					new Course { Id = 2, Name = "Science", Mark = 79 },
					new Course { Id = 3, Name = "Literature", Mark = 79 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 79 }
				}
			};
			var students = new Student[] { studentA, studentB };
			foreach (var student in students)
			{
				var results = tracker.HasGraduated(diploma, student);
				Assert.AreEqual(results.Item2, STANDING.Average);
			}
		}
		[TestMethod]
		public void StudentsWithAnAverageBetween80And95HaveMagnaCumLaudeStanding()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var studentA = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 80 },
					new Course { Id = 2, Name = "Science", Mark = 80 },
					new Course { Id = 3, Name = "Literature", Mark = 80 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 80 }
				}
			};
			var studentB = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 94 },
					new Course { Id = 2, Name = "Science", Mark = 94 },
					new Course { Id = 3, Name = "Literature", Mark = 94 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 94 }
				}
			};
			var students = new Student[] { studentA, studentB };
			foreach (var student in students)
			{
				var results = tracker.HasGraduated(diploma, student);
				Assert.AreEqual(results.Item2, STANDING.MagnaCumLaude);
			}
		}
		[TestMethod]
		public void StudentsWithAnAverageAbove95HaveSumaCumLaudeStanding()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var student = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 95 },
					new Course { Id = 2, Name = "Science", Mark = 95 },
					new Course { Id = 3, Name = "Literature", Mark = 95 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 95 }
				}
			};
			var results = tracker.HasGraduated(diploma, student);
			Assert.AreEqual(results.Item2, STANDING.SumaCumLaude);
		}
		[TestMethod]
		public void OnlyRelevantCoursesCountTowardTheAverage()
		{
			var tracker = new GraduationTracker();
			var diploma = new Diploma
			{
				Id = 1,
				Credits = 4,
				// Math, Science, Literature, Physichal Education
				Requirements = new int[] { 100, 102, 103, 104 }
			};
			var student = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course { Id = 1, Name = "Math", Mark = 95 },
					new Course { Id = 2, Name = "Science", Mark = 95 },
					new Course { Id = 3, Name = "Literature", Mark = 95 },
					new Course { Id = 4, Name = "Physichal Education", Mark = 95 },
					new Course { Id = 5, Name = "Pottery", Mark = 0 },
				}
			};
			var results = tracker.HasGraduated(diploma, student);
			Assert.AreEqual(results.Item2, STANDING.SumaCumLaude);
		}
	}
}
