using Entitas;

namespace Beta
{
	[Game] public sealed class ShootComponent : IComponent { }
	
	[Game] public sealed class BulletSpawnerComponent : IComponent { public BulletSpawner Value; }
	
	[Game] public sealed class BulletComponent : IComponent { }
}