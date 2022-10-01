namespace UnitTests
{
	public class TestClassBook
	{
		public bool isRead; 
		public byte authorYears;
		public char firstLetter;
		public double height;
		public float width;
		public int pages;
		public long price;
		public short rewiewAmount;
		public string? name;
		public List<string> anotherBooks;

		public TestClassBook(int pages, List<string> anotherBooks) 
		{
			this.pages = pages;
			this.anotherBooks = anotherBooks;
		}
	}

	public struct TestStruct
	{
		public int intField;
		public string stringField;
	}
}
