using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class ReviveScreen : MonoBehaviour
	{
		[SerializeField] private GameObject _root;
		[SerializeField] private Button _button;

		private bool Active { set => _root.SetActive(value); }

		public static ReviveScreen Instance { get; private set; }

		private void Awake()
		{
			Instance ??= this;
			Hide();
		}

		private void OnEnable()  => _button.onClick.AddListener(Revive);
		private void OnDisable() => _button.onClick.RemoveListener(Revive);

		public void Show() => Active = true;

		public void Hide() => Active = false;

		private void Revive()
		{
			Vector2.zero.SendAsSpawnPlayerMessage();
			Hide();
		}
	}
}