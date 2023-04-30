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
			
		}
	}
}