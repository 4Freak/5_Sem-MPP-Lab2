namespace Faker
{
	public interface IValueGenerator
	{
		Type GeneratedType {get; }

		object Generate(Type typeToGenerate, GeneratorContext context);
		bool CanGenerate(Type type);
	}
}
