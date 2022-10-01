using Faker.Generators;
using System.Reflection;

namespace UnitTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase(typeof(bool))]
		[TestCase(typeof(byte))]
		[TestCase(typeof(char))]
		[TestCase(typeof(double))]
		[TestCase(typeof(float))]
		[TestCase(typeof(int))]
		[TestCase(typeof(long))]
		[TestCase(typeof(short))]
		[TestCase(typeof(string))]
		[TestCase(typeof(List<string>))]
		[TestCase(typeof(List<TestClassBook>))]
		public void SimpleTypes(Type type)
		{
			// Arrange
			var faker = new Faker.Core.Faker();

			// Act
			var testVar = faker.Create(type);

			// Assert
			Assert.IsFalse(testVar.Equals(GeneratorObject.GetDefaultValue(type)));

			Assert.Pass();
		}

		[Test]
		public void ObjectTest()
		{
			// Arrange
			var faker = new Faker.Core.Faker();
			bool result = true;

			// Act
			var book = faker.Create<TestClassBook>();

			// Assert
			var fields = book.GetType().GetFields(BindingFlags.Public);
			foreach (var field in fields)
			{
				if (Equals(field.GetValue(book), GeneratorObject.GetDefaultValue(field.FieldType)))
				{
					result = false;
				}
			}

			//var properties = book.GetType().GetProperties(BindingFlags.Public);
			//foreach (var property in properties)
			//{
			//	if (Equals(property.GetValue(book), GeneratorObject.GetDefaultValue(property.PropertyType)))
			//	{
			//		result = false;
			//	}				
			//}
			Assert.IsTrue(result);

			Assert.Pass();
		}

		[Test]
		public void StructTest()
		{
			// Arrange
			var faker = new Faker.Core.Faker();	
			
			// Act 
			TestStruct s = faker.Create<TestStruct>();

			// Assert
			Assert.Multiple (() => 
			{
				Assert.IsFalse(s.intField.Equals(GeneratorObject.GetDefaultValue(s.intField.GetType())));
				Assert.IsFalse(s.stringField.Equals(GeneratorObject.GetDefaultValue(s.stringField.GetType())));
			});
		}
	}
}