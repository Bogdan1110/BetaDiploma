using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Beta
{
	[Game] public sealed class ShootComponent : IComponent { }

	[Game] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
	
	[Game] public sealed class NetIdComponent : IComponent { [PrimaryEntityIndex] public uint Value; }
	
	[Game] public sealed class InstanceIdComponent : IComponent { [PrimaryEntityIndex] public int Value; }

	[Game] public sealed class BulletSpawnerComponent : IComponent { public BulletSpawner Value; }
	
	[Game] public sealed class BulletComponent : IComponent { }
	
	[Game] public sealed class TargetPositionComponent : IComponent { public Vector2 Value; }
	
	[Game] public sealed class OwnerInstanceIdComponent : IComponent { [EntityIndex] public int Value; }
}