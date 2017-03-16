public partial class GameEntity {

    public VelocityComponent velocity { get { return (VelocityComponent)GetComponent(GameComponentsLookup.Velocity); } }
    public bool hasVelocity { get { return HasComponent(GameComponentsLookup.Velocity); } }

    public void AddVelocity(UnityEngine.Vector3 newValue) {
        var component = CreateComponent<VelocityComponent>(GameComponentsLookup.Velocity);
        component.value = newValue;
        AddComponent(GameComponentsLookup.Velocity, component);
    }

    public void ReplaceVelocity(UnityEngine.Vector3 newValue) {
        var component = CreateComponent<VelocityComponent>(GameComponentsLookup.Velocity);
        component.value = newValue;
        ReplaceComponent(GameComponentsLookup.Velocity, component);
    }

    public void RemoveVelocity() {
        RemoveComponent(GameComponentsLookup.Velocity);
    }
}

public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVelocity;

    public static Entitas.IMatcher<GameEntity> Velocity {
        get {
            if(_matcherVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Velocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocity = matcher;
            }

            return _matcherVelocity;
        }
    }
}