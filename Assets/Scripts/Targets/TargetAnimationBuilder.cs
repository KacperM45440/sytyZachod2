using System.Collections.Generic;

public enum targetAnimation
{
    dblLeft,
    dblRight,
    stop3Sec,
    leftSpinny,
    rightSpinny
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
        },
        {
            targetAnimation.leftSpinny,
            new[]
            {
                animationStep.Left,
                animationStep.Spinny
            }
        },
        {
            targetAnimation.rightSpinny,
            new[]
            {
                animationStep.Right,
                animationStep.SpinnyMirror
            }
        },
    };
}