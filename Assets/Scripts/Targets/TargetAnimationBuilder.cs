using System.Collections.Generic;

public enum targetAnimation
{
    dblLeft,
    dblRight,
    stop3Sec
}

public enum animationStep
{
    Left,
    Right,
    Up,
    Down,
    Spinny,
    SpinnyMirror,
    ZigZag,
    DownLow,
    Still
}

public static class AnimationDatabase
{
    public static readonly Dictionary<targetAnimation, animationStep[]> Animations = new()
    {
        {
            targetAnimation.dblLeft,
            new[]
            {
                animationStep.Left,
                animationStep.Left
            }
        },
        {
            targetAnimation.dblRight,
            new[]
            {
                animationStep.Right,
                animationStep.Right
            }
        },
        {
            targetAnimation.stop3Sec,
            new[]
            {
                animationStep.Still,
                animationStep.Still,
                animationStep.Still
            }
        }
    };
}