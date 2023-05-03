using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class DamageHitEntitiesWithHealthSystem : ReactiveSystem<GameEntity>
	{
		public DamageHitEntitiesWithHealthSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(DamageDealt, CurrentHealth));

		protected override bool Filter(GameEntity entity) => entity.hasDamageDealt;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.ReplaceCurrentHealth(e.currentHealth.Value - e.damageDealt.Value);
			}
		}
	}
}