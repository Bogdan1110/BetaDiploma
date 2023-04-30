using System.Collections.Generic;
using Entitas;
using Mirror;
using UnityEngine;

namespace Beta
{
	public sealed class BindPositionViewsSystem : ReactiveSystem<GameEntity>
	{
		private readonly PositionView _viewPrefab;

		public BindPositionViewsSystem(Contexts contexts, PositionView view)
			: base(contexts.game)
			=> _viewPrefab = view;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Position);

		protected override bool Filter(GameEntity entity)
			=> entity.hasPosition && entity.hasPositionListener == false;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var view = Object.Instantiate(_viewPrefab);
				view.RegisterListener(entity);
				NetworkServer.Spawn(view.gameObject);
			}
		}
	}
}