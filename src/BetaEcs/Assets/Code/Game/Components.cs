using Entitas;
using Entitas.CodeGeneration.Attributes;
using Mirror;
using UnityEngine;

namespace Beta
{
	[Game] public sealed class PlayerComponent : IComponent { }

	[Game] [Event(EventTarget.Self)] public sealed class PositionComponent : IComponent { public Vector2 Value; }
	
	[Game] public sealed class NetworkIdentityComponent : IComponent { public NetworkIdentity Value; }
}