using Mirror;
using UnityEngine;

namespace Beta
{
	public class DeathView : NetworkBehaviour, IDeadListener
	{
		[SerializeField] private GameObject _gameObject;

		public void OnDead(GameEntity entity) => _gameObject.SetActive(entity.isDead == false);
	}
}