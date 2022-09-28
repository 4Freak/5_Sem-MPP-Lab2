using Faker.Context;
using Faker.Interface;

namespace Faker.Generators
{
	internal class GeneratorDouble : IValueGenerator
	{
		public Type GeneratedType {get; } = typeof(double);
		
		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return context.Random.Next(1, int.MaxValue) / int.MaxValue * 4;
		}

		public bool CanGenerate(Type type)
		{
			return type == GeneratedType;
		}
	}
}
