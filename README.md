A junior developer has just accomplished a task suspicously fast...and went for lunch.
There are now unit tests breaking on the build server and only you have the skills to fix it.

You should 

  - Clone this repo
  - Create a branch in your clone
  - Fix the broken unit test
  - Make sure there is adequate test coverage.
  - Make sure all code is clean and follows best practices 
  
When finished, make a pull request against the master branch in your clone and send us a link to your repo.

All joking aside, there is no need to finish this in the span of a lunch hour. 

The test is so you can show us what clean code looks like. Clean it up as best you can!

You will be joining a team that believes in S.O.L.I.D.D principles. We favour declaritive over imperative programming. And we generally use rich service models, with anemic domain models, which looks very much like SOA over REST.

Submissions that follow these principles will be favored since you will fit right in with the current team. If there is a part of the test that blocks you from completing it, then put some comments explaing why it was blocking, and what you would have done if the obstacle was removed.

Good Luck!


---
---
# Solution Description:
---
## Patterns used:
* **Strategy Pattern**
    - **Interface used:** IGraduationStandingRetriever
    - **Classes involved:** StandingRemedial, StandingAverage, StandingMagnaCumLaude, StandingSumaCumLaude
The above classes are created to represent the standing values: Remedy, Average, MagnaCumLaude, SumaCumLaude. IGraduationStandingRetriever has a method to return the graduation status & Standing which will be implemented in all the above said classes.

* **Factory Pattern**
    - **Classes involved:** StandingFactory
Standing is calculated based on the average. Here I have used the StandingFactory class to create the instance of appropriate Standing class based on the average marks.

# SOLID Principles used:

* **Single Responsibility Principle**
    - ScoreCalculator class is responsible for handling score calculation.
    - StandingFactory class is responsible for creating standing instances based on average.
    - AppDatabase is the class that provides the data for the application.
    - DiplomaDAO, RequirementDAO, StudentDAO are the Data Access Object classes which implements the interface IDBReader for retrieving the data from database instance injected into the DAO classes.
* **Dependency Inversion Principle**
    
    - DiplomaDAO, RequirementDAO, StudentDAO, GraduationTracker classes depend on the abstraction IDatabase so that it is loosely coupled with the database instance and can be easily swapped by any class that implements IDatabase. This makes it easier to inject the mock database instance while unit testing

# Unit test case coverage:
I have written test cases with maximum code coverage.
