using UnityEngine;

public enum act
{
    togglePause,


    walkForward,
    walkBackward,
    walkLeft,
    walkRight,
    run,


    hit1,
    hit2,


    interact,
    throws
}
public class MapInput
{
    // UI control button
    public static readonly KeyCode togglePauseKey = KeyCode.Escape;

    // Movement control buttons
    public static readonly KeyCode walkForwardKey  = KeyCode.W;
    public static readonly KeyCode walkBackwardKey = KeyCode.S;
    public static readonly KeyCode walkLeftKey     = KeyCode.A;
    public static readonly KeyCode walkRightKey    = KeyCode.D;
    public static readonly KeyCode runKey           = KeyCode.LeftShift;

    // Combat control buttons
    public static readonly KeyCode hit1Key = KeyCode.Mouse0;
    public static readonly KeyCode hit2Key = KeyCode.Mouse1;

    // Action control buttons
    public static readonly KeyCode interactKey = KeyCode.E;
    public static readonly KeyCode throwKey = KeyCode.Q;

}
