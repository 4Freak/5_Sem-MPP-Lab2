using Faker.Exeprion;
using Faker.Interface;
using System.Reflection;

namespace Faker.Generators
{
	public class GeneratorObject
	{
		private readonly IFaker _faker;

		public GeneratorObject(IFaker faker)
		{
			_faker = faker;
		}

		public object CreateObject(Type type)
		{
			var constructors = type.GetConstructors(BindingFlags.Public)
				.OrderByDescending(j => j.GetParameters().Length)
				.ToList();
			
			foreach (var constructor in constructors)
			{
                    var arguments = constructor.GetParameters()
                        .Select(i => i.ParameterType)
						.Select(_faker.Create)
                        .ToArray();

					return constructor.Invoke(arguments);
			}

			if (type.IsValueType)
			{
				return Activator.CreateInstance(type);
			}

			throw new FakerException("Cannot use public constructors");
		}
		public object FillObject(object item)
		{
			var fields = item.GetType().GetFields(BindingFlags.Public);
			foreach (var field in fields)
			{
				if (Equals(field.GetValue(item), GetDefaultValue(item.GetType())))
				{
					field.SetValue(item, GetDefaultValue(item.GetType()));
				}
			}

			var properties = item.GetType().GetProperties(BindingFlags.Public);
			foreach (var property in properties)
			{
				if (Equals(property.GetValue(item), GetDefaultValue(item.GetType())))
				{
					property.SetValue(item, GetDefaultValue(item.GetType()));
				}
				
			}
			return item;
		}

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
	}
}
