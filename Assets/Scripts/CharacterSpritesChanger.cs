using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemies : int
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
    public bool dualEnemies = false;

    [SerializeField] private List<EnemySpriteSet> enemySprites;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private SpriteRenderer hatRenderer;
    [SerializeField] private GameObject dualEnemiesParent;
    [SerializeField] private SpriteRenderer dualEnemySpriteRenderer1;
    [SerializeField] private SpriteRenderer dualEnemySpriteRenderer2;
    [SerializeField] private GameObject hatContainer;

    private enemies currentEnemy;
    private EnemySpriteSet currentEnemySpriteSet;
    private EnemySpriteSet currentDualEnemySpriteSet2;
    private enemySpriteType currentEnemySpriteType;
    private Coroutine punchedCoroutine;

    public void Start()
    {
        if (currentEnemySpriteSet == null)
        {
            currentEnemySpriteSet = enemySprites[0];
        }
    }

    public void SetEnemy(enemies enemy)
    {
        currentEnemy = enemy;
        currentEnemySpriteSet = enemySprites[(int)currentEnemy];

        if(currentEnemy == enemies.pineappleCoconut)
        {
            dualEnemies = true;
            enemySpriteRenderer.gameObject.SetActive(false);
            dualEnemiesParent.SetActive(true);
            currentDualEnemySpriteSet2 = enemySprites[enemySprites.Count - 1];
        }
        ChangeEnemySprite(enemySpriteType.idle);
    }

    public void ChangeEnemySprite(enemySpriteType type)
    {
        currentEnemySpriteType = type;
        Sprite mainEnemySprite = GetSpriteByType(currentEnemySpriteType, currentEnemySpriteSet);

        if (!dualEnemies)
        {
            enemySpriteRenderer.sprite = mainEnemySprite;
        }
        else
        {
            dualEnemySpriteRenderer1.sprite = mainEnemySprite;
            dualEnemySpriteRenderer2.sprite = GetSpriteByType(currentEnemySpriteType, currentDualEnemySpriteSet2);
        }

        //Special cases
        if (currentEnemySpriteType == enemySpriteType.defeated && currentEnemySpriteSet.hat != null)
        {
            SpawnHat();
        }
        
        if (currentEnemySpriteType == enemySpriteType.punched)
        {
            if (punchedCoroutine != null)
            {
                StopCoroutine(punchedCoroutine);
            }
            punchedCoroutine = StartCoroutine(SwitchBackFromPunched());
        }
    }

    public void ChangeSpriteOneOfDual(enemySpriteType type, SpriteRenderer renderer)
    {
        enemySpriteType previousType = currentEnemySpriteType;

        ChangeEnemySprite(type);

        if (renderer == dualEnemySpriteRenderer1)
        {
            dualEnemySpriteRenderer2.sprite = GetSpriteByType(previousType, currentDualEnemySpriteSet2);
        }
        else if (renderer == dualEnemySpriteRenderer2)
        {
            dualEnemySpriteRenderer1.sprite = GetSpriteByType(previousType, currentEnemySpriteSet);
        }
    }

    private Sprite GetSpriteByType(enemySpriteType type, EnemySpriteSet spriteSet)
    {
        return type switch
        {
            enemySpriteType.idle => spriteSet.idle,
            enemySpriteType.hurt => spriteSet.hurt,
            enemySpriteType.defeated => spriteSet.defeated,
            enemySpriteType.dominated => spriteSet.dominated,
            enemySpriteType.dead => spriteSet.dead,
            enemySpriteType.punched => spriteSet.punched[Random.Range(0, spriteSet.punched.Length)],
            _ => spriteSet.idle,
        };
    }

    private IEnumerator SwitchBackFromPunched()
    {
        yield return new WaitForSeconds(0.3f);
        if(currentEnemySpriteType == enemySpriteType.punched)
        {
            ChangeEnemySprite(enemySpriteType.dominated);
        }
    }

    private void SpawnHat()
    {
        hatRenderer.gameObject.SetActive(true);
        hatRenderer.transform.parent = hatContainer.transform;
        hatRenderer.sprite = currentEnemySpriteSet.hat;
    }
}
