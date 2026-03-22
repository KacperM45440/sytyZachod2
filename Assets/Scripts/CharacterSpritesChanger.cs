using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum enemySprites : int
{
    cucumberWestern = 0,
    banana = 1,
    starFruit = 2,
    pineappleCoconut = 3,
    dragonFruit = 4,
    cucumberBahama = 5
}

public enum  enemySpriteType
{
    idle,
    hurt,
    defeated,
    dominated,
    dead,
    punched
}

[System.Serializable]
public class EnemySpriteSet
{
    public Sprite idle;
    public Sprite hurt;
    public Sprite defeated;
    public Sprite dominated;
    public Sprite dead;
    public Sprite[] punched;
}

public class CharacterSpritesChanger : MonoBehaviour
{
    [SerializeField] private List<EnemySpriteSet> enemySprites;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;

    private EnemySpriteSet currentEnemySpriteSet;

    public void Start()
    {
        if (currentEnemySpriteSet == null)
        {
            currentEnemySpriteSet = enemySprites[0];
        }
    }

    public void SetEnemy(enemySprites sprite)
    {
        currentEnemySpriteSet = enemySprites[(int)sprite];
        ChangeEnemySprite(enemySpriteType.idle);
    }

    public void ChangeEnemySprite(enemySpriteType type)
    {
        Sprite setSprite = currentEnemySpriteSet.idle;
        switch (type)
        {
            case enemySpriteType.idle:
                setSprite = currentEnemySpriteSet.idle;
                break;
            case enemySpriteType.hurt:
                setSprite = currentEnemySpriteSet.hurt;
                break;
            case enemySpriteType.defeated:
                setSprite = currentEnemySpriteSet.defeated;
                break;
            case enemySpriteType.dominated:
                setSprite = currentEnemySpriteSet.dominated;
                break;
            case enemySpriteType.dead:
                setSprite = currentEnemySpriteSet.dead;
                break;
            case enemySpriteType.punched:
                int i = Random.Range(0, currentEnemySpriteSet.punched.Length);
                setSprite = currentEnemySpriteSet.punched[i];
                break;
        }
        enemySpriteRenderer.sprite = setSprite;
    }
}
