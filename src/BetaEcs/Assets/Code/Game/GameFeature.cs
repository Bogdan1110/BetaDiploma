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
			Add(new SpawnPlayerSystem(contexts, playerPrefab));
			Add(new SpawnPlayerByPressingSpaceSystem(contexts));
			Add(new BindPositionViewsSystem(contexts, playerPrefab.GetComponent<PositionView>()));

			Add(new MovePlayer(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}