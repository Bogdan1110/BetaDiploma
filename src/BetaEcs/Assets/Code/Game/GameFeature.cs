namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			// Initialization
			Add(new ServicesRegistrationFeature(contexts));
			Add(new SpawnCursorSystem(contexts));
			Add(new PlayerLookAtCursorSystem(contexts));
			
			// Update
			Add(new PlayerMovementSystem(contexts));
			Add(new TrackCursorPositionSystem(contexts));

			// Entitas Generated
			Add(new GameEventSystems(contexts));
		}
	}
}