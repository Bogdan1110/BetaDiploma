using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] public sealed class OverlapCircleRadiusComponent : IComponent { public float Value; }

	[Game] [Cleanup(CleanupMode.RemoveComponent)] public sealed class CollidedComponent : IComponent { }

	[Game] [Cleanup(CleanupMode.RemoveComponent)] public sealed class CollisionIdComponent : IComponent { [EntityIndex] public uint Value; }

	[Game] public sealed class HittableComponent : IComponent { }
}