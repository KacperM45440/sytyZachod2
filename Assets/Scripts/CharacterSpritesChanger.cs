using NUnit.Framework;
using System.Collections;
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
    public Sprite hat;
}

public class CharacterSpritesChanger : MonoBehaviour
{
    [SerializeField] private List<EnemySpriteSet> enemySprites;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private SpriteRenderer hatRenderer;

    private enemySprites currentEnemy;
    private EnemySpriteSet currentEnemySpriteSet;
    private enemySpriteType currentEnemySpriteType;
    private Coroutine punchedCoroutine;

    public void Start()
    {
        if (currentEnemySpriteSet == null)
        {
            currentEnemySpriteSet = enemySprites[0];
        }
    }

    public void SetEnemy(enemySprites sprite)
    {
        currentEnemy = sprite;
        currentEnemySpriteSet = enemySprites[(int)currentEnemy];
        ChangeEnemySprite(enemySpriteType.idle);
    }

    public void ChangeEnemySprite(enemySpriteType type)
    {
        currentEnemySpriteType = type;
        Sprite setSprite = currentEnemySpriteSet.idle;
        switch (currentEnemySpriteType)
        {
            case enemySpriteType.idle:
                setSprite = currentEnemySpriteSet.idle;
                break;
            case enemySpriteType.hurt:
                setSprite = currentEnemySpriteSet.hurt;
                break;
            case enemySpriteType.defeated:
                setSprite = currentEnemySpriteSet.defeated;
                if (currentEnemySpriteSet.hat != null)
                {
                    EnableHat();
                }
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
                if(punchedCoroutine != null)
                {
                    StopCoroutine(punchedCoroutine);
                }
                punchedCoroutine = StartCoroutine(SwitchBackFromPunched());
                break;
        }
        enemySpriteRenderer.sprite = setSprite;
    }

    private IEnumerator SwitchBackFromPunched()
    {
        yield return new WaitForSeconds(0.3f);
        if(currentEnemySpriteType == enemySpriteType.punched)
        {
            ChangeEnemySprite(enemySpriteType.dominated);
        }
    }

    private void EnableHat()
    {
        hatRenderer.gameObject.SetActive(true);
        hatRenderer.transform.parent = gameObject.transform;
        hatRenderer.sprite = currentEnemySpriteSet.hat;
    }
}
