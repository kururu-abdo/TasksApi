using System;
namespace Tasks.Domain
{
	public class UserTask
	{
		public int Id { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateUpdated { get; set; }

		public DateTime DueDate { get; set; }

		public int TaskStatus { get; set; }

	}
}

