using UnityEngine;

namespace Beta
{
	public interface ITimeService
	{
		float DeltaTime { get; }

		float FixedDeltaTime { get; }
	}

	public class TimeService : ITimeService
	{
		public float DeltaTime => Time.deltaTime;

		public float FixedDeltaTime => Time.fixedDeltaTime;
	}
}