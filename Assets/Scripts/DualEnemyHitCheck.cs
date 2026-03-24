using UnityEngine;

public class DualEnemyHitCheck : MonoBehaviour
{
    [SerializeField] private GunScript gunRef;
    [SerializeField] private BackgroundScript backgroundScriptRef;
    [SerializeField] private EnemyHitCheck parentHitCheckRef;

    private Animator animatorRef;
    private SpriteRenderer rendererRef;
    private Collider2D colliderRef;

    private void Start()
    {
        animatorRef = GetComponent<Animator>();
        colliderRef = GetComponent<Collider2D>();
        rendererRef = GetComponentInChildren<SpriteRenderer>();

        colliderRef.enabled = false;
    }

    public void OnMouseEnter()
    {
        parentHitCheckRef.OnMouseEnter();
    }

    public void OnMouseExit()
    {
        parentHitCheckRef.OnMouseExit();
    }

    private void OnMouseDown()
    {
        if (gunRef.readyToFire)
        {
            gunRef.ShotFired();
            parentHitCheckRef.ShotOneOfDualEnemy();
            backgroundScriptRef.KillOneOfDualEnemy(animatorRef, rendererRef);
            colliderRef.enabled = false;
        }
    }
}
