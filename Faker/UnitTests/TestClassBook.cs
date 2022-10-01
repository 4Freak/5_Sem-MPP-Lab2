namespace UnitTests
{
	public class TestClassBook
	{

		public const int I = 10;
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

	class A
	{
		public B b { get; set; }
		public B b2 { get; set; }
	}

	class B
	{
		public C c { get; set; }
	}

	class C
	{
		public A  a { get; set; } 
	}
}
