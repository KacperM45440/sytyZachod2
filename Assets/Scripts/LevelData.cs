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
    red = 1,
    hole = 2,
    shrink = 3,
    splat = 4
}

public class LevelData
{
    public List<TargetData> finishedTable;

    // W tej klasie przechowywane sa dane kazdego poziomu, typ, wlasciwosci, kolejnosc celow oraz przerwy pomiedzy nimi.
    // O ile logicznym wydaje siê przechowywanie takich danych w oddzielnym miejscu, tak nie uda³o znaleŸæ mi siê informacji *jak dobrze to zrobiæ*.
    // W ten sposób? Przypisaæ je w edytorze? Pod³¹czyæ pod plik .json?

    public void Level1()
    {
        // Predkosc pierwszego poziomu wynosi 1 i jest podwajana w rundzie drugiej

        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblRight, spawnLocation = new Vector2(1f, 0f), delay = 2f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.red, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.red, animation = targetAnimation.dblRight, spawnLocation = new Vector2(1f, 0f), delay = 3f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblRight, spawnLocation = new Vector2(1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(-1f, 0f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(1f, 0f), delay = 2f });
        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(-1f, -1f), delay = 1f });
        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(1f, 1f), delay = 3f });

        finishedTable = table;
    }
}