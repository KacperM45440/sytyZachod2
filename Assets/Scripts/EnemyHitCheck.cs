using UnityEngine;

public class EnemyHitCheck : MonoBehaviour
{
    [SerializeField] private TransitionScript cursorTransitionRef;
    [SerializeField] private GunScript gunRef;

    private Collider2D enemyCollider;

    private void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        enemyCollider.enabled = false;
    }

    public void EnableHitCheck()
    {
        enemyCollider.enabled = true;
    }

    private void OnMouseEnter()
    {
        cursorTransitionRef.ChooseCursor(cursorType.crosshairKill);
    }

    private void OnMouseExit()
    {
        cursorTransitionRef.ChooseCursor(cursorType.crosshairShooting);
    }

    private void OnMouseDown()
    {
        if (gunRef.readyToFire)
        {
            gunRef.ShotFired();
            WinCheck.Instance.FinishingShot();
            enemyCollider.enabled = false;
        }
    }
}
