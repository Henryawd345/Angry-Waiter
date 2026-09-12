using UnityEngine;

public static class InputHandler
{
    public static bool pressing(act input) {return Input.GetKey(checkInput(input));}
    public static bool pressed(act input) {return Input.GetKeyDown(checkInput(input));}


    private static KeyCode checkInput(act action) => action switch
    {
        act.togglePause  => MapInput.togglePauseKey,
        act.walkForward  => MapInput.walkForwardKey,
        act.walkBackward => MapInput.walkBackwardKey,
        act.walkLeft     => MapInput.walkLeftKey,
        act.walkRight    => MapInput.walkRightKey,
        act.run          => MapInput.runKey,
        act.hit1         => MapInput.hit1Key,
        act.hit2         => MapInput.hit2Key,
        act.interact     => MapInput.interactKey,
        act.throws       => MapInput.throwKey,
        _                => KeyCode.None
    };
}
