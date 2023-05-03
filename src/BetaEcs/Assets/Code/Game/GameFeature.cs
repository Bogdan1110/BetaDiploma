namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			RegisterServices(contexts);
			Gameplay(contexts);
			CallEntitasGeneratedStuff(contexts);
		}

		private void Gameplay(Contexts contexts)
		{
			Initialize(contexts);
			ReadInput(contexts);
			UpdateLogic(contexts);
		}

		private void Initialize(Contexts contexts)
		{
			Add(new SpawnCursorSystem(contexts));
			Add(new PlayerLookAtCursorSystem(contexts));
		}

		private void ReadInput(Contexts contexts)
		{
			Add(new SendShootSignalSystem(contexts));
			Add(new PlayerMovementSystem(contexts));
			Add(new TrackCursorPositionSystem(contexts));
		}

		private void UpdateLogic(Contexts contexts)
		{
			Add(new SpawnBulletsSystem(contexts));

			Add(new ResetBalanceValuesSystem(contexts));

			Add(new MoveToTargetSystem(contexts));
			Add(new LookAtTargetSystem(contexts));

			Add(new DestroyReachedTargetEntitesSystem(contexts));
			Add(new DestroyNetworkBehaviourSystem(contexts));
		}

		private void RegisterServices(Contexts contexts) => Add(new ServicesRegistrationFeature(contexts));

		private void CallEntitasGeneratedStuff(Contexts contexts)
		{
			Add(new GameEventSystems(contexts));
			Add(new GameCleanupSystems(contexts));
		}
	}
}