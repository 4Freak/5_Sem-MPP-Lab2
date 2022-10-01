namespace Faker
{
	public class GeneratorContext
	{
		public Random Random {get; }
		public IFaker Faker {get; }

		public GeneratorContext(Random random, IFaker faker)
		{
			this.Random = random;
			this.Faker = faker;
		}
	}
}
