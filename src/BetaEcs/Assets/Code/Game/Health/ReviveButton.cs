using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class ReviveButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		private void OnEnable() => _button.onClick.AddListener(Revive);
		private void OnDisable() => _button.onClick.RemoveListener(Revive);

		private void Revive()
		{
			foreach (var player in FindObjectsOfType<PlayerBehaviour>())
			{
				if (player.isLocalPlayer)
				{
					
				}
			}
		}
	}
}