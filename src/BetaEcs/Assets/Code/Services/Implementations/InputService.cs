using UnityEngine;

namespace Beta
{
	public interface IInputService
	{
		public Vector2 MovementDirection { get; }

		public Vector2 CursorPosition { get; }
	}

	public class OldInputService : IInputService
	{
		public Vector2 MovementDirection => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		public Vector2 CursorPosition => Input.mousePosition;
	}
}