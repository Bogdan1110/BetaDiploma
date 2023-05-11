using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Beta
{
	[Game] [FlagPrefix("markTo")] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
	
	[Game] public sealed class IdComponent : IComponent { [PrimaryEntityIndex] public uint Value; }
	
	[Game] public sealed class OwnerIdComponent : IComponent { [EntityIndex] public uint Value; }
	
	[Game] [Event(Self)] public sealed class DeadComponent : IComponent { }
}