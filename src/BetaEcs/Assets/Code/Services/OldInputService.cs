using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Services
{
	public interface IInputService
	{
		public Vector2 Movement { get; }
	}

	public class OldInputService : IInputService
	{
		public Vector2 Movement => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}