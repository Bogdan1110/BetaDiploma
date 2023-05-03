using System;
using UnityEngine;

namespace Beta
{
	[Serializable]
	public class BulletBalance
	{
		[field: SerializeField] public float Speed  { get; private set; }
		[field: SerializeField] public float Radius { get; private set; }
		[field: SerializeField] public int   Damage { get; private set; }
	}
}