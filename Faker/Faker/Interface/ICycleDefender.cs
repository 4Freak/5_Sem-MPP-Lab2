namespace Faker
{
	public interface ICycleDefender
	{
		
		bool CheckCycleDependence(Type type);

		void CleanCycleDependence(Type type);
	}
}
