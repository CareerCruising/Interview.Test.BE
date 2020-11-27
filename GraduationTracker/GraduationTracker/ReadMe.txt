Preface
I feel that the code illustrated the question itself however some requirements are unclear but it is all
a test for me to get creative and apply my own business rules for what is ambiguous.  I dont understand
why requirements has a credits property and why a course has one as well so I made the credits property
of the requirement class pull hte sum of credits property in course class that it entails.

DB Relationships
So examining the code first database modelling, I am assume the DB relationships are as follows:

-Diploma can have multiple requirements and one requirement can pertain to one or more diplomas
-requirements can have on or more courses while one course can belong to mulitple requirements, I am thinking 
 something like a science requirement can contain multiple courses like biology, chemistry and physics
-Then one student can only be working towards one diploma at once
-Student and courses obviously also implies a many to many relationship

Averages
In the junior developer's code the average of a student's marks is a average of those courses that belongs
to a diploma's requirements.  If a student for example have 4 course which concurs to requirements, and if 
they one course that is not, then the mark for this one course will not be calculated towards the student's 
average which I dont know if this is the business requirement so I implemented 2 average functions in the 
student class which will take all marks of all courses summing it up and dividing it up by the number of 
courses that recurred in the sum disregarding if a course pertains to the required requirsments

Object Oriented Design 
In a domain driven design distinguishes between repositories for DB access of data, entities and business logic
layers.  However, this is a small test program with limited logic which can be implemented in the entity classes
itself and not complexed enough to have business logic layer classes. Thus, the GraduationTracker class library
contains only repository and entity classes forming a 2 tiered archirtecture.

The student class contains all the methods required to output business logic into front end interfaces or webapis
and are classes that can be reused and extended.  In all of the repository classes contains empty add, update and
delete methods.  These CRUD methods interacts with the entity classes with the visitor pattern as demonstrated
in the StudentCourse class is how a entities and repository can interact.

Mocking in Unit Test
We need to mock data for repositories for white box / boundary testing is the reason why I created a singleton
factory class with RepositoryFactory and RepositoryFactoryBase classes which demonstrated the abstract factory
design pattern.  The default RepositoryFactory class is assumed to return production data inheriting the 
RepositoryFactoryBase abstract class.  Any mock factory classes inheriting RepositoryFactoryBase can be used 
to return mock data by also overriding the repository classes and then including the instantiations of this
repository class within the mock factory to generate mock data.

I had overriden a few mock repositories and a example of how RepositoryFactoryBase can be extended in the 
Mocks folder in the unit test project.  Also the RepositoryFactoryBase.RepositoryFactoryName and 
RepositoryFactoryBase.RepositoryFactoryNamespace static properties will have to be configured to 
point to you mock RepositoryFactory classes to inject mock data into the entity classes consuming repositories.

I do also undertand that there are nuget unit testing frameworks that can be used to mock data, but I used
a design pattern instead to overcome this issue of mocking.

Unit Testing
There is a unit test class corresponding to each class in the GraduationTracker class library except for those
entity classes that dont have any methods.  As mentioned, the student class is the class that contains all the 
methods that should be called to gain your graduation fucntionalities so that is the class that I had
been doing more extensive testing with data mocking.  The test cases arent complete and since the design is set
I think I should be passing this back to the junior developer to complete extending more test cases with
mocking and more test classes needs to be written for boundary structure testing.

