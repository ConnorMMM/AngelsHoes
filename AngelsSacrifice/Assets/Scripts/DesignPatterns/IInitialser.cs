namespace BLASTER_RIVALS.DesignPatterns
{
	public interface IInitialiser
	{
		public bool Initialised { get; }

		public void Initialise(params object[] _params);
	}
}