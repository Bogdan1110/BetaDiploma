using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] public sealed class ShootComponent : IComponent { }

	[Game] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
}