namespace GraduationTracker
{
	/// <summary>
	/// Requirement towards Diploma completion.
	/// </summary>
	public class Requirement
	{
		public int Id { get; set; }
		public string Name { get; set; }
		/// <summary>
		/// The minimum mark that needs to be met for this Requirement to be fulfilled.
		/// </summary>
		public int MinimumMark { get; set; }
		/// <summary>
		/// If the minimum mark is met, how many Credits this Requirement makes towards Diploma completion.
		/// </summary>
		public int Credits { get; set; }
		/// <summary>
		/// Ids of the Courses that can be taken to fulfill this Requirement.
		/// If a single Course meets the minimum mark, then this Requirement counts as fulfilled.
		/// </summary>
		public int[] Courses { get; set; }
	}
}
