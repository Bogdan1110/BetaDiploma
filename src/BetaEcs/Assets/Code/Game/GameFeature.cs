using UnityEngine;

namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			Add(new SpawnPlayerByPressingSpaceSystem(contexts));
			Add(new BindPositionViewsSystem(contexts, Resources.Load<PositionView>("Player/Player")));

			Add(new MovePlayer(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}