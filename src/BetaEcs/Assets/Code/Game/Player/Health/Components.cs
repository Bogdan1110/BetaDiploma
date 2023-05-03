using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] [Event(EventTarget.Self)] public sealed class CurrentHealthComponent : IComponent { public int Value; }

	[Game] [Event(EventTarget.Self)] public sealed class MaxHealthComponent : IComponent { public int Value; }
}