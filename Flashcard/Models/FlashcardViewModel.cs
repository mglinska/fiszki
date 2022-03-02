namespace Flashcard.Models
{
	public class Flashpage
	{
		public string Word { get; set; }
		public string Description { get; set; }
		public int Evaluation { get; set; }
	}

	public class Flashcard {
		public Flashpage Avers { get; set; }
		public Flashpage Revers { get; set; }
	}

	public record FlascardViewModel
	{
		public Flashcard FCard { get; set; }
		public List<Flashcard> FCards { get; set; }
	}
}
