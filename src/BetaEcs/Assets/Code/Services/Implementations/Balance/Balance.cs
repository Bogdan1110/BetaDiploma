using UnityEngine;

namespace Beta
{
	public interface IBalanceService
	{
		PlayerBalance Player { get; }
		BulletBalance Bullet { get; }
	}

	[CreateAssetMenu(fileName = nameof(Balance), menuName = nameof(Beta) + "/" + nameof(Balance), order = 0)]
	public class Balance : ScriptableObject, IBalanceService
	{
		[field: SerializeField] public PlayerBalance Player { get; private set; }
		[field: SerializeField] public BulletBalance Bullet { get; private set; }
	}
}