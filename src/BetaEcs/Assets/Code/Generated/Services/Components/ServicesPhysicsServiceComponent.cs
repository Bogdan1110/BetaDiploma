//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServicesContext {

    public ServicesEntity physicsServiceEntity { get { return GetGroup(ServicesMatcher.PhysicsService).GetSingleEntity(); } }
    public Beta.PhysicsServiceComponent physicsService { get { return physicsServiceEntity.physicsService; } }
    public bool hasPhysicsService { get { return physicsServiceEntity != null; } }

    public ServicesEntity SetPhysicsService(Beta.IPhysicsService newValue) {
        if (hasPhysicsService) {
            throw new Entitas.EntitasException("Could not set PhysicsService!\n" + this + " already has an entity with Beta.PhysicsServiceComponent!",
                "You should check if the context already has a physicsServiceEntity before setting it or use context.ReplacePhysicsService().");
        }
        var entity = CreateEntity();
        entity.AddPhysicsService(newValue);
        return entity;
    }

    public void ReplacePhysicsService(Beta.IPhysicsService newValue) {
        var entity = physicsServiceEntity;
        if (entity == null) {
            entity = SetPhysicsService(newValue);
        } else {
            entity.ReplacePhysicsService(newValue);
        }
    }

    public void RemovePhysicsService() {
        physicsServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServicesEntity {

    public Beta.PhysicsServiceComponent physicsService { get { return (Beta.PhysicsServiceComponent)GetComponent(ServicesComponentsLookup.PhysicsService); } }
    public bool hasPhysicsService { get { return HasComponent(ServicesComponentsLookup.PhysicsService); } }

    public void AddPhysicsService(Beta.IPhysicsService newValue) {
        var index = ServicesComponentsLookup.PhysicsService;
        var component = (Beta.PhysicsServiceComponent)CreateComponent(index, typeof(Beta.PhysicsServiceComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePhysicsService(Beta.IPhysicsService newValue) {
        var index = ServicesComponentsLookup.PhysicsService;
        var component = (Beta.PhysicsServiceComponent)CreateComponent(index, typeof(Beta.PhysicsServiceComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePhysicsService() {
        RemoveComponent(ServicesComponentsLookup.PhysicsService);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ServicesMatcher {

    static Entitas.IMatcher<ServicesEntity> _matcherPhysicsService;

    public static Entitas.IMatcher<ServicesEntity> PhysicsService {
        get {
            if (_matcherPhysicsService == null) {
                var matcher = (Entitas.Matcher<ServicesEntity>)Entitas.Matcher<ServicesEntity>.AllOf(ServicesComponentsLookup.PhysicsService);
                matcher.componentNames = ServicesComponentsLookup.componentNames;
                _matcherPhysicsService = matcher;
            }

            return _matcherPhysicsService;
        }
    }
}
