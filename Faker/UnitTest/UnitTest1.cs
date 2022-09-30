namespace UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			// Arrange
			var faker = new Faker.Core.Faker();
			// Act
			bool b = faker.Create<bool>();
			byte byt = faker.Create<byte>();
			char c = faker.Create<char>();
			double d = faker.Create<double>();
			float f = faker.Create<float>();
			int i = faker.Create<int>();
			long l = faker.Create<long>();
			short s = faker.Create<short>();
			string str = faker.Create<string>();
			// Assert

		}
	}
}