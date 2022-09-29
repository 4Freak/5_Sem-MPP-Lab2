using Faker.Core;
using System.Runtime.InteropServices;

namespace Faker.Example
{
	public class Example
	{
		public static void Main(string[] argv)
		{
			var faker = new Faker.Core.Faker();
			bool b = faker.Create<bool>();
			Console.WriteLine(b);

		}
	}
}
