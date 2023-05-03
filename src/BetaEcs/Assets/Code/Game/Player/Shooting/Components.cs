using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Beta
{
	[Game] public sealed class ShootComponent : IComponent { }

	[Game] [FlagPrefix("markTo")] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
	
	[Game] public sealed class IdComponent : IComponent { [PrimaryEntityIndex] public int Value; }

	[Game] public sealed class BulletSpawnerComponent : IComponent { public BulletSpawner Value; }
	
	[Game] public sealed class BulletComponent : IComponent { }
	
	[Game] public sealed class TargetPositionComponent : IComponent { public Vector2 Value; }
	
	[Game] public sealed class OwnerIdComponent : IComponent { [EntityIndex] public int Value; }
	
	[Game] public sealed class SpeedComponent : IComponent { public float Value; }
	
	[Game] public sealed class DestroyUponReachingTargetComponent : IComponent { }
	
	[Game] public sealed class OverlapCircleRadiusComponent : IComponent { public float Value; }
	
	[Game] [Cleanup(CleanupMode.RemoveComponent)] public sealed class CollidedComponent : IComponent { }

	[Game] [Cleanup(CleanupMode.RemoveComponent)] public sealed class CollisionIdComponent : IComponent { [EntityIndex] public int Value; }

	[Game] public sealed class HitComponent : IComponent { }

	[Game] public sealed class HittableComponent : IComponent { }
}