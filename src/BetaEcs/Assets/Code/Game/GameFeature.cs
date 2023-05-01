namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			Add(new ServicesRegistrationFeature(contexts));

			Add(new PlayerMovementSystem(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}