using Faker.Context;
using Faker.Interface;
using Faker.Generators;

namespace Faker.Core
{
    public class Faker : IFaker
    {
		private readonly  GeneratorContext _generatorContext;
		private readonly Dictionary<Type, IValueGenerator> _valueGenerators;

		public Faker()
		{
			_generatorContext = new GeneratorContext(new Random(), this);
			_valueGenerators = new Dictionary<Type, IValueGenerator>();

			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(i => i.GetTypes())
				.Where(j => typeof(IValueGenerator).IsAssignableFrom(j) && j.IsClass);

			foreach (var type in types)
			{	
				var gen = (IValueGenerator?)Activator.CreateInstance(type);
				if (gen != null)
				{
					_valueGenerators.Add(gen.GeneratedType, gen);
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
			if (_valueGenerators.ContainsKey(type) && _valueGenerators[type].CanGenerate(type))
			{
				return _valueGenerators[type].Generate(type, _generatorContext);
			}


			var objectGenerator = new GeneratorObject(this);
			object item = objectGenerator.CreateObject(type);
			return objectGenerator.FillObject(item);
			
        }
    }
}
