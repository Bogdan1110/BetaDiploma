using Entitas;

namespace Beta
{
	[Game] public sealed class CursorComponent : IComponent { }

	[Game] public sealed class RotationComponent : IComponent { public float Value; }
	
	[Game] public sealed class LookAtComponent : IComponent { public GameEntity Value; }
}