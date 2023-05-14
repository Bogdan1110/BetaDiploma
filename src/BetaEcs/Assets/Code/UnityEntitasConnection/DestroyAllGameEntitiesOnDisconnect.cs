using UnityEngine;

namespace Beta
{
	public class DestroyAllGameEntitiesOnDisconnect : MonoBehaviour
	{
		private void OnDestroy() => Contexts.sharedInstance.game.DestroyAllEntities();
	}
}