using Faker.Context;
using Faker.Interface;

namespace Faker.Generators
{
	internal class GeneratorByte : IValueGenerator
	{
	    
		private const int _minByte = 1;
		public Type GeneratedType {get; } = typeof(byte);
		
		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return context.Random.Next(_minByte, byte.MaxValue);
		}

		public bool CanGenerate(Type type)
		{
			return type == GeneratedType;
		}
	}
}
