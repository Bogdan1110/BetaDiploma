using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] [FlagPrefix("markTo")] [Cleanup(CleanupMode.DestroyEntity)] public sealed class DestroyComponent : IComponent { }
	
	[Game] public sealed class IdComponent : IComponent { [PrimaryEntityIndex] public uint Value; }
	
	[Game] public sealed class OwnerIdComponent : IComponent { [EntityIndex] public uint Value; }
	
}