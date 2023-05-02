using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Game] public sealed class CursorComponent : IComponent { }

	[Game] [Event(EventTarget.Self)] public sealed class RotationComponent : IComponent { public float Value; }

	[Game] public sealed class LookAtComponent : IComponent { public GameEntity Value; }
}