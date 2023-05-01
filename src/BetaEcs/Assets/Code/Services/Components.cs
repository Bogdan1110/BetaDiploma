using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Beta
{
	[Services] [Unique] public sealed class InputServiceComponent : IComponent { public IInputService Value; }

	[Services] [Unique] public sealed class BalanceServiceComponent : IComponent { public IBalanceService Value; }
	
	[Services] [Unique] public sealed class TimeServiceComponent : IComponent { public ITimeService Value; }
	
	[Services] [Unique] public sealed class CameraServiceComponent : IComponent { public ICameraService Value; }
}