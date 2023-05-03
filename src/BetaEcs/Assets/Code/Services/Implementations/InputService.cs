using UnityEngine;

namespace Beta
{
	public interface IInputService
	{
		public Vector2 MovementDirection { get; }

		public Vector2 CursorPosition { get; }

		bool IsLeftMouseButtonClicked { get; }
	}

	public class OldInputService : IInputService
	{
		private const int LeftMouseButton = 0;
		private const string HorizontalAxis = "Horizontal";
		private const string VerticalAxis = "Vertical";

		public Vector2 MovementDirection => new(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));

		public Vector2 CursorPosition => Input.mousePosition;

		public bool IsLeftMouseButtonClicked => Input.GetMouseButtonDown(LeftMouseButton);
	}
}