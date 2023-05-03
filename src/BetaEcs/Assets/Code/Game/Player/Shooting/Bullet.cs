using Mirror;
using UnityEngine;

namespace Beta
{
	public class Bullet : NetworkBehaviour
	{
		private readonly Collider2D[] _buffer = new Collider2D[1];

		private bool _initialized;
		private Vector3 _target;

		[Server]
		public void Initialize(uint owner, Vector3 target)
		{
			_target = target;
			_initialized = true;
		}

		private void FixedUpdate()
		{
			if (_initialized == false
			    || isServer == false)
			{
				return;
			}

			transform.Translate((_target - transform.position).normalized * (ServicesMediator.Time.FixedDeltaTime * 5f));

			if (Physics2D.OverlapCircleNonAlloc(transform.position, 0.5f, _buffer) > 0)
			{
				var item = _buffer[0];
				var instanceID = item.GetInstanceID();
				Debug.Log($"Collided with instanceID = {instanceID}");
			}

			if (Vector3.Distance(transform.position, _target) < 0.1f)
			{
				NetworkServer.Destroy(gameObject);
			}
		}
	}
}