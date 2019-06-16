# What I've did

* Comments added to classes, methods and code logic in general

* All test data (diploma, student) moved from the GraduationTrackerTest class to Repository class 
  to allow reuse for all test cases and beter separation/readability

* Created more students to test different scenarios

* Credit's logic modified at GraduationTracker, before, when a student achieved the minimum mark on a 
  requirement, the credits for that requirement were accumulated but not used anywhere. Now, the credit 
  is accumulated on student's course and can be used to check if the student has credits

* Fixed the TestHasCredits() test

* Created TestHasNoCredits(), TestHasGraduated() and TestHasNotGraduated() unit tests to improve coverage

* Using LINQ to query data when possible to improve readability

That's all folks, best regards and thanks for this opportunity.
