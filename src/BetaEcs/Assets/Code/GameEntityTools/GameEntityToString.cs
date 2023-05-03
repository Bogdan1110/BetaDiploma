// ReSharper disable CheckNamespace - parts of classes suppose to de in same namespace as original class
public sealed partial class GameEntity
{
	public override string ToString() => hasDebugName
		? $"{creationIndex}_{debugName.Value}"
		: $"{creationIndex}_{base.ToString()}";
}