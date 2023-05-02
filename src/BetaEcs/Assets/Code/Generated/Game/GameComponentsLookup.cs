//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Cursor = 0;
    public const int Destroy = 1;
    public const int LookAt = 2;
    public const int NetworkIdentity = 3;
    public const int Player = 4;
    public const int Position = 5;
    public const int Rotation = 6;
    public const int Shoot = 7;
    public const int PositionListener = 8;
    public const int RotationListener = 9;

    public const int TotalComponents = 10;

    public static readonly string[] componentNames = {
        "Cursor",
        "Destroy",
        "LookAt",
        "NetworkIdentity",
        "Player",
        "Position",
        "Rotation",
        "Shoot",
        "PositionListener",
        "RotationListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Beta.CursorComponent),
        typeof(Beta.DestroyComponent),
        typeof(Beta.LookAtComponent),
        typeof(Beta.NetworkIdentityComponent),
        typeof(Beta.PlayerComponent),
        typeof(Beta.PositionComponent),
        typeof(Beta.RotationComponent),
        typeof(Beta.ShootComponent),
        typeof(PositionListenerComponent),
        typeof(RotationListenerComponent)
    };
}
