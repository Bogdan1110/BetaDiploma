using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] public sealed class ShootComponent : IComponent { }

	[Game] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
	
	[Game] public sealed class NetIdComponent : IComponent { public uint Value; }
	
	[Game] public sealed class InstanceIdComponent : IComponent { public int Value; }
}