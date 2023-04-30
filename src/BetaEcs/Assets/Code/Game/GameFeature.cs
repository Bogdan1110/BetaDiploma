using Unity.VisualScripting;
using UnityEngine;

namespace Beta
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts)
			: base(nameof(GameFeature))
		{
			var playerPrefab = Resources.Load("Player/Player");
			Add(new BindPositionViewsSystem(contexts, playerPrefab.GetComponent<PositionView>()));

			Add(new PlayerMovementSystem(contexts));
			Add(new SyncPlayerSystem(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}