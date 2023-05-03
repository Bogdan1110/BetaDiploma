using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Beta
{
	[Game] [Event(EventTarget.Self)] public sealed class PositionComponent : IComponent { public Vector2 Value; }

	[Game] public sealed class SpeedComponent : IComponent { public float Value; }
	
	[Game] public sealed class TargetPositionComponent : IComponent { public Vector2 Value; }
	
	[Game] public sealed class DestroyUponReachingTargetComponent : IComponent { }
}