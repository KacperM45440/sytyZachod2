using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData
{
    public targetType targetType;
    public targetAnimation animation;
    public float delay;
    public Vector2 spawnLocation;
}

public enum targetType : int
{
    normal = 0,
    shield = 1,
    hole = 2,
    shrink = 3,
    splat = 4,
    fast = 5
}

public class LevelData
{
    public List<TargetData> finishedTable;

    public float levelSpeed = 1f;
    public float levelSpeedBoosted = 2f;

    // W tej klasie przechowywane sa dane kazdego poziomu, typ, wlasciwosci, kolejnosc celow oraz przerwy pomiedzy nimi.
    // Hard limity dla umieszczenia targetów to x: -6 do 6, y: -2 do 3

    public void Level0()
    {
        levelSpeed = 0.8f;
        levelSpeedBoosted = 1.2f;
        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblRight, spawnLocation = new Vector2(-3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(0f, 0.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblRight, spawnLocation = new Vector2(3f, 3f), delay = 1.5f });


        finishedTable = table;
    }

    public void Level1()
    {
        levelSpeed = 1f;
        levelSpeedBoosted = 1.5f;
        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(-3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(0f, 0.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(3f, 3f), delay = 1.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(0f, 0.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(-3f, 3f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(-3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(0f, 0.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(3f, 3f), delay = 1.5f });


        finishedTable = table;
    }

    public void Level2()
    {
        levelSpeed = 1f;
        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.leftThenCircleUp, spawnLocation = new Vector2(0f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.leftThenCircleUp, spawnLocation = new Vector2(0f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.leftThenCircleUp, spawnLocation = new Vector2(0f, 0f), delay = 2f });
        table.Add(new TargetData() { targetType = targetType.shield, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.shield, animation = targetAnimation.dblRight, spawnLocation = new Vector2(1f, 0f), delay = 3f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(1f, 0f), delay = 2f });
        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(-1f, -1f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(1f, 1f), delay = 3f });

        finishedTable = table;
    }

    public void Level3()
    {
        List<TargetData> table = new();
        finishedTable = table;
    }

    public void Level4()
    {
        List<TargetData> table = new();
        finishedTable = table;
    }

    public void Level5()
    {
        List<TargetData> table = new();
        finishedTable = table;
    }
}