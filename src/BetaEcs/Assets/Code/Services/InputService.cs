using UnityEngine;

namespace Beta
{
	public interface IInputService
	{
		public Vector2 MovementDirection { get; }
	}

	public class OldInputService : IInputService
	{
		public Vector2 MovementDirection => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}