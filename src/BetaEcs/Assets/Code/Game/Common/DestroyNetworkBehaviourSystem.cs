using System.Collections.Generic;
using Entitas;
using Mirror;
using static GameMatcher;

namespace Beta
{
	public sealed class DestroyNetworkBehaviourSystem : ReactiveSystem<GameEntity>
	{
		public DestroyNetworkBehaviourSystem(Contexts contexts) : base(contexts.game) { }

		private static IMatcher<GameEntity> NetworkIdentity => GameMatcher.NetworkIdentity;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(NetworkIdentity, Destroy));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				NetworkServer.Destroy(e.networkIdentity.Value.gameObject);
			}
		}
	}
}