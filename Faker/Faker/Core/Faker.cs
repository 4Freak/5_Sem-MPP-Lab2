using Faker.Generators;

namespace Faker
{
	public class Faker : IFaker
	{
		private readonly GeneratorContext _generatorContext;
		private readonly List<IValueGenerator> _valueGenerators;
		private readonly CycleDefender _cycleDefender;

		static bool CheckSubType(Type t1, Type t2)
		{
			bool result = t1.GetInterface(t2.Name) != null;

			return result;
		}

		public Faker()
		{

			_generatorContext = new GeneratorContext(new Random(), this);
			_valueGenerators = new List<IValueGenerator>();
			_cycleDefender = new CycleDefender(4);

			var testTypes = new List<Type>()
			{
				typeof(string),
			};

			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(i => i.GetTypes())
				.Where(j => typeof(IValueGenerator).IsAssignableFrom(j) && !j.IsInterface && CheckSubType(j, typeof(IValueGenerator)))
				.ToList();

			foreach (var type in types)
			{
				var gen = (IValueGenerator?)Activator.CreateInstance(type);
				if (gen != null)
				{
					_valueGenerators.Add(gen);
				}
			}
		}

		public T Create<T>()
		{
			return (T)CreateItem(typeof(T));
		}

		public object Create(Type type)
		{
			return CreateItem(type);
		}
		private object CreateItem(Type type)
		{
			foreach (var gen in _valueGenerators)
			{
				if (gen.CanGenerate(type))
				{
					return gen.Generate(type, _generatorContext);
				}
			}
			
			if (!_cycleDefender.CheckCycleDependence(type))
			{
				return null;
			}
			var objectGenerator = new GeneratorObject(this);
			object item = objectGenerator.CreateObject(type);

			_cycleDefender.CleanCycleDependence();
			return objectGenerator.FillObject(item);
		}
	}
}
