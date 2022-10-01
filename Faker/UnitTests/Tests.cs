
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
		[TestCase(typeof(List<List<List<string>>>))]
		[TestCase(typeof(List<TestClassBook>))]
		public void SimpleTypes(Type type)
		{
			var faker = new Faker.Faker();

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
			var faker = new Faker.Faker();
			bool result = true;

			// Act
			var book = faker.Create<TestClassBook>();

			// Assert
			var fields = book.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (var field in fields)
			{
				if (Equals(field.GetValue(book), GeneratorObject.GetDefaultValue(field.FieldType)))
				{
					result = false;
				}
			}

			Assert.IsTrue(result);

			Assert.Pass();
		}

		[Test]
		public void StructTest()
		{
			// Arrange
			var faker = new Faker.Faker();	
			
			// Act 
			TestStruct s = faker.Create<TestStruct>();

			// Assert
			Assert.Multiple (() => 
			{
				Assert.IsFalse(s.intField.Equals(GeneratorObject.GetDefaultValue(s.intField.GetType())));
				Assert.IsFalse(s.stringField.Equals(GeneratorObject.GetDefaultValue(s.stringField.GetType())));
			});
			Assert.Pass();
		}

		[Test]
		public void CycleTest()
		{
			// Arrange
			var faker = new Faker.Faker();

			// Act

			var cycleClass = faker.Create<A>();


			// Assert 
			Assert.IsFalse(cycleClass.Equals(GeneratorObject.GetDefaultValue(cycleClass.GetType())));				
			
			// Can return false if change CycleDefender._threathold
			Assert.IsTrue(Equals(cycleClass.b.c.a.b.c.a.b.c.a.b.c.a, GeneratorObject.GetDefaultValue(cycleClass.GetType())));
			Assert.Pass();
		}
	}
}