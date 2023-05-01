using System;
using UnityEngine;

namespace Beta
{
	[Serializable]
	public class PlayerBalance
	{
		[field: SerializeField] public float Speed { get; private set; }
	}
}