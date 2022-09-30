using System.Diagnostics.CodeAnalysis;

namespace Faker.Exeprion
{
	public class FakerException : Exception
	{
		public FakerException(string message) : base(message) {}
	}
}
