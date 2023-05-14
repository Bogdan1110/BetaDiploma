using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class MainMenuMediator : MonoBehaviour
	{
		[SerializeField] private Networking _networking;
		[Header("UI elements")]
		[SerializeField] private Button _startHostButton;
		[SerializeField] private Button _startServerButton;
		[SerializeField] private Button _startClientButton;
		[SerializeField] private TMP_InputField _addressInputField;
		[SerializeField] private Button _quitButton;

		private void OnEnable()
		{
			_startHostButton.onClick.AddListener(_networking.StartHost);
			_startServerButton.onClick.AddListener(_networking.StartServer);
			_startClientButton.onClick.AddListener(_networking.StartClient);
			_addressInputField.onEndEdit.AddListener(UpdateIpAddress);
			_quitButton.onClick.AddListener(QuitGame);
		}

		private void OnDisable()
		{
			_startHostButton.onClick.RemoveListener(_networking.StartHost);
			_startServerButton.onClick.RemoveListener(_networking.StartServer);
			_startClientButton.onClick.RemoveListener(_networking.StartClient);
			_addressInputField.onEndEdit.RemoveListener(UpdateIpAddress);
			_quitButton.onClick.RemoveListener(QuitGame);
		}

		private void UpdateIpAddress(string value) => _networking.networkAddress = value;

		private void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
		}
	}
}