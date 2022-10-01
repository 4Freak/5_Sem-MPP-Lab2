using System.Diagnostics.CodeAnalysis;

namespace Faker
{
	public class FakerException : Exception
	{
		public FakerException(string message) : base(message) {}
	}
}
