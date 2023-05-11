using System;
using UnityEngine;

namespace Beta
{
	[Serializable]
	public class FieldBalance
	{
		[field: SerializeField] public Vector2 MinPositions { get; private set; }
		[field: SerializeField] public Vector2 MaxPositions { get; private set; }
	}
}