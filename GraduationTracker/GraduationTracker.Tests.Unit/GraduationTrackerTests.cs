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
        public void TestNotGraudatedWithoutOneGoodMark()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                               {
                                    new Course{Id = 1, Name = "Math", Mark=95 },
                                    new Course{Id = 2, Name = "Science", Mark=40 },
                                    new Course{Id = 3, Name = "Literature", Mark=95 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                               }
            };

            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(false, STANDING.MagnaCumLaude)));
        }

        [TestMethod]
        public void TestNotGraudatedWithoutGoodMarks()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
                           {
                               Id = 1,
                               Courses = new Course[]
                               {
                                    new Course{Id = 1, Name = "Math", Mark=35 },
                                    new Course{Id = 2, Name = "Science", Mark=40 },
                                    new Course{Id = 3, Name = "Literature", Mark=25 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=15 }
                               }
                           };

            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(false, STANDING.Remedial)));
        }

        [TestMethod]
        public void TestHasGraudated()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                               {
                                    new Course{Id = 1, Name = "Math", Mark=95 },
                                    new Course{Id = 2, Name = "Science", Mark=90 },
                                    new Course{Id = 3, Name = "Literature", Mark=95 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                               }
            };

            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude)));
        }

        [TestMethod]
        public void TestNotGraudatedWithoutTakingAnyCourses()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]{}
            };
            var temp = tracker.HasGraduated(diploma, student);
            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(false, STANDING.None)));
        }

        [TestMethod]
        public void TestNotGraudatedWithoutTakingAllCourses()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                               {
                                    new Course{Id = 1, Name = "Math", Mark=95 },
                                    new Course{Id = 2, Name = "Science", Mark=90 },
                                    new Course{Id = 3, Name = "Literature", Mark=95 }
                               }
            };

            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(false, STANDING.MagnaCumLaude)));
        }

        [TestMethod]
        public void TestHasGraudatedWithExtraCourses()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var student = new Student
            {
                Id = 1,
                Courses = new Course[]
                               {
                                    new Course{Id = 1, Name = "Math", Mark=95 },
                                    new Course{Id = 2, Name = "Science", Mark=90 },
                                    new Course{Id = 3, Name = "Literature", Mark=95 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=95 },
                                    new Course{Id = 5, Name = "Music", Mark=92 }
                               }
            };

            Assert.IsTrue(tracker.HasGraduated(diploma, student).Equals(new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude)));
        }

        [TestMethod]
        public void TestNoneGraduated()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=15 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=20 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }


            //tracker.HasGraduated()
        };
            
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach(var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }
            
            Assert.IsTrue(graduated.Where(a=>a.Item1 == true).Count() == 0);

        }

        [TestMethod]
        public void TestOneNotGraduated()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=85 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=90 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=90 },
                    new Course{Id = 2, Name = "Science", Mark=80 },
                    new Course{Id = 3, Name = "Literature", Mark=70 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=90 }
                }
            }


            //tracker.HasGraduated()
        };

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Where(a => a.Item1 == true).Count() == students.Length - 1);

        }

        [TestMethod]
        public void TestAllGraduated()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=85 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=90 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=60 },
                    new Course{Id = 2, Name = "Science", Mark=70 },
                    new Course{Id = 3, Name = "Literature", Mark=80 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=90 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=90 },
                    new Course{Id = 2, Name = "Science", Mark=80 },
                    new Course{Id = 3, Name = "Literature", Mark=70 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=90 }
                }
            }


            //tracker.HasGraduated()
        };

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Where(a => a.Item1 == true).Count() == students.Length);

        }

    }
}
