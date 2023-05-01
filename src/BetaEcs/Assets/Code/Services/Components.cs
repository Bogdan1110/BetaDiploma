using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Services] [Unique] public sealed class InputServiceComponent : IComponent { public IInputService Value; }
}