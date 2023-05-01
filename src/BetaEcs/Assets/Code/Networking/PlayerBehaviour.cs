using Mirror;
using UnityEngine;

namespace Beta
{
	public class PlayerBehaviour : NetworkBehaviour
	{
		[SerializeField] private NetworkIdentity _networkIdentity;
		[SerializeField] private PositionView _positionView;

		private void Start()
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isPlayer = true;
			e.AddNetworkIdentity(_networkIdentity);
			e.AddPosition(transform.position);
			_positionView.RegisterListener(e);
			e.AddRotation(0f);
		}
	}
}