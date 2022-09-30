namespace Faker.Interface
{
    public interface IFaker
    {	
		T Create<T>();
		object Create(Type type);
    }
}
