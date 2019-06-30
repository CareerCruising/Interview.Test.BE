namespace GraduationTracker
{
	public class Student
	{
		public int Id { get; set; }

		/// <summary>
		/// Collection of courses that the student is enrolled in.
		/// </summary>
		public Course[] Courses { get; set; }
	}
}
