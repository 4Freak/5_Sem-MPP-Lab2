using System.Runtime.CompilerServices;

namespace UnitTests
{
	public class Tests
	{
     	private static object GetDefaultValue(Type type)
		{
			if (type.IsValueType)
			{
				return Activator.CreateInstance(type);
			}
			else
			{
				return null;
			}
	
		}

		[SetUp]
		public void Setup()
		{
		}

		[TestCase(typeof(bool))]
		[TestCase(typeof(byte))]
		[TestCase(typeof(char))]
		[TestCase(typeof(double))]
		[TestCase(typeof(float))]
		[TestCase(typeof(int))]
		[TestCase(typeof(long))]
		[TestCase(typeof(short))]
		[TestCase(typeof(String))]
		public void SimpleTypes(Type type)
		{
			// Arrange
			var faker = new Faker.Core.Faker();

			// Act
			var testVar = faker.Create(type);

			// Assert
			Assert.IsFalse(testVar.Equals(GetDefaultValue(type)));

			Assert.Pass();
		}
	}
}