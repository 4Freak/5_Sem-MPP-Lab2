namespace Faker
{
	public class CycleDefender : ICycleDefender
	{
	
		private readonly Dictionary<Type, int> _generatedTypes = new Dictionary<Type, int>();
		private readonly int _threathold;

		public CycleDefender(int threathold)
		{
			this._threathold = threathold;
		}
		public bool CheckCycleDependence(Type type)
		{
			if (_generatedTypes.ContainsKey(type))
			{
				_generatedTypes[type]++;
			}
			else
			{
				_generatedTypes.Add(type, 1);
			}
			if (_generatedTypes[type] > _threathold)
			{
				return false;
			}
			return true;
		}
		
		public void CleanCycleDependence(Type type)
		{
			_generatedTypes[type]--;  
		}
	}
}
