using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class DestroyCollidedBulletSystem : ReactiveSystem<GameEntity>
	{
		public DestroyCollidedBulletSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Collided, Bullet));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.markToDestroy = true;
			}
		}
	}
}