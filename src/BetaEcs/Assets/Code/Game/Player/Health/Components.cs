using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Beta
{
	[Game] [Event(Self)] public sealed class CurrentHealthComponent : IComponent { public int Value; }

	[Game] [Event(Self)] public sealed class MaxHealthComponent : IComponent { public int Value; }
	
	[Game] public sealed class DamageComponent : IComponent { public int Value; }

	[Game] [Cleanup(RemoveComponent)] public sealed class DamageDealtComponent : IComponent { public int Value; }
}