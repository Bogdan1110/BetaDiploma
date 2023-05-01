using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Beta
{
	public class GameMenu : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		[SerializeField] private Button _joinButton;
		[SerializeField] private TMP_InputField _serverAddressInput;

		private void OnEnable()
		{
			_startButton.onClick.AddListener(OnStartButtonClicked);
			_joinButton.onClick.AddListener(OnJoinButtonClicked);
		}

		private void OnDisable()
		{
			_startButton.onClick.RemoveListener(OnStartButtonClicked);
			_joinButton.onClick.RemoveListener(OnJoinButtonClicked);
		}

		private void OnStartButtonClicked()
		{
			// Start the server
			NetworkManager.singleton.StartServer();

			// Load the GameScene
			SceneManager.LoadScene("Gameplay Scene");
		}

		private void OnJoinButtonClicked()
		{
			// Connect to the server
			string serverAddress = _serverAddressInput.text;
			NetworkManager.singleton.networkAddress = serverAddress;
			NetworkManager.singleton.StartClient();

			// Load the GameScene when successfully connected to the server
			NetworkClient.RegisterHandler<ConnectMessage>(OnConnected);
		}

		private void OnConnected(ConnectMessage connectMessage)
		{
			NetworkClient.UnregisterHandler<ConnectMessage>();
			SceneManager.LoadScene("Gameplay Scene");
		}
	}
}