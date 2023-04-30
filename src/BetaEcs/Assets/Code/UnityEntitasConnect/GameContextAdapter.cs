namespace Beta
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		protected override Feature GetFeature() => new GameFeature(Contexts);
	}
}