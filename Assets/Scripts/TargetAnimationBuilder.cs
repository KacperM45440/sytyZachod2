using System.Collections.Generic;

public enum targetAnimation
{
    dblLeft,
    dblRight,
}

public enum animationStep
{
    Left,
    Right,
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
        }
    };
}