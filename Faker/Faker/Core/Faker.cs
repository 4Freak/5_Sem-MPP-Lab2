﻿using Faker.Context;
using Faker.Interface;

namespace Faker.Core
{
    internal class Faker : IFaker
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
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
			GeneratorContext generatorContext = _generatorContext;

			if (_valueGenerators.ContainsKey(type) && _valueGenerators[type].CanGenerate(type))
			{
				return _valueGenerators[type].Generate(type, generatorContext);
			}
			return null;
        }
    }
}
