namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			Add(new PlayerSpawnSystem(contexts));

			// Add(new BindPositionViewsSystem(contexts, Resources.Load("Player/Player").GetComponent<PositionView>()));

			Add(new PlayerMovementSystem(contexts));
			Add(new SyncPlayerSystem(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}