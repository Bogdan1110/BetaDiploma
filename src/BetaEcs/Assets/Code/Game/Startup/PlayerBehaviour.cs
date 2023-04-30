using Mirror;
using UnityEngine;

namespace Beta
{
	public class PlayerBehaviour : NetworkBehaviour
	{
		[SerializeField] private float _speed = 5f;

		private void Update()
		{
			if (isOwned)
			{
				MostSimpleMovement();
			}
		}

		private void MostSimpleMovement()
		{
			var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			var scaledSpeed = _speed * Time.deltaTime;

			transform.Translate(direction * scaledSpeed);
		}
	}
}