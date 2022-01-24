Using S.O.L.I.D principles:

SRP -> Breaking the base repo to different repos with a single responsibility.

OCP -> I violated this principle when I made the relationship between courses and students to be many to many, as well as the relationship between course and requierment to be one to one and changing the marks plus the minimum mark to float, including removing Mark from course model and put it in StudentCourses Model.

LSP -> Any drived class (student can fulfill the need for baseModel class).

ISP -> Broke down the application to interfaces. I created IBaseModel where I could have all the other attributes of Student, Diploma, Requierment, Course, StudentCourse, but the issue is that I’ll be forcing to implement these attributes to wherever I use IBaseModel, so I created the other interfaces of the models so I’m not forcing these attributes to be applied.

DIP -> In GraduationTracker it uses the IStudent and IDiploma interfaces because it relays on the abstraction not implementation.