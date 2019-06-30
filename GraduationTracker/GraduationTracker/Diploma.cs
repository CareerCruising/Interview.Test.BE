namespace GraduationTracker
{
	public class Diploma
	{
		public int Id { get; set; }

		/// <summary>
		/// Amount of credits required for this Diploma?
		/// </summary>
		public int Credits { get; set; }

		/// <summary>
		/// Ids of the Requirements of this Diploma
		/// </summary>
		public int[] Requirements { get; set; }
	}
}
