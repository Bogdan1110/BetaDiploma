using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class LeaveGameButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		private void OnEnable()  => _button.onClick.AddListener(Leave);
		private void OnDisable() => _button.onClick.RemoveListener(Leave);

		private static NetworkManager Networking => NetworkManager.singleton;

		private static bool IsHost => IsServer && IsClient;

		private static bool IsServer => NetworkServer.active;

		private static bool IsClient => NetworkClient.isConnected;

		private void Leave()
		{
			if (IsHost)
			{
				Networking.StopHost();
				return;
			}

			if (IsClient)
			{
				Networking.StopClient();
				return;
			}

			if (IsServer)
			{
				Networking.StopServer();
			}
		}
	}
}