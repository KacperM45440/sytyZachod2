using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCheck : MonoBehaviour
{
    [SerializeField] private TransitionScript cursorTransitionRef;
    [SerializeField] private GunScript gunRef;
    [SerializeField] private Animator charactersAnimatorRef;
    [SerializeField] private CharacterSpritesChanger characterSpitesChangerRef;
    [SerializeField] private BackgroundScript backgroundScriptRef;
    [SerializeField] private Collider2D dualEnemyColliderRef1;
    [SerializeField] private Collider2D dualEnemyColliderRef2;

    private Collider2D enemyCollider;
    private int dualEnemiesShot = 0;

    private void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        enemyCollider.enabled = false;
    }

    public void EnableHitCheck()
    {
        charactersAnimatorRef.SetTrigger("PullOutGun");

        if(!characterSpitesChangerRef.dualEnemies)
        {
            enemyCollider.enabled = true;
        }
        else
        {
            dualEnemyColliderRef1.enabled = true;
            dualEnemyColliderRef2.enabled = true;
        }
    }

    public void OnMouseEnter()
    {
        cursorTransitionRef.ChooseCursor(cursorType.crosshairKill);
    }

    public void OnMouseExit()
    {
        cursorTransitionRef.ChooseCursor(cursorType.crosshairShooting);
    }

    private void OnMouseDown()
    {
        if (gunRef.readyToFire)
        {
            gunRef.ShotFired();
            backgroundScriptRef.KillEnemy();
            WinCheck.Instance.FinishingShot();
            enemyCollider.enabled = false;
        }
    }

    public void ShotOneOfDualEnemy()
    {
        dualEnemiesShot++;
        if(dualEnemiesShot >= 2)
        {
            WinCheck.Instance.FinishingShot();
        }
    }
}
