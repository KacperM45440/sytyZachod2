using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShieldedBehaviour : TargetBehaviour
{
    [SerializeField] private GameObject shieldShards;
    [SerializeField] private Sprite shieldBrokenSprite;

    private SpriteRenderer rendererRef;
    private Animator shieldShardsAnimator;
    private bool hasShield = true;

    protected override void Start()
    {
        base.Start();
        rendererRef = GetComponent<SpriteRenderer>();
        shieldShardsAnimator = shieldShards.GetComponent<Animator>();
    }

    public override void OnClick()
    {
        if (!gun.readyToFire)
        {
            return;
        }

        if (hasShield)
        {
            hasShield = false;
            rendererRef.sprite = shieldBrokenSprite;
            PlayShardsAnimation(shieldShards, shieldShardsAnimator);

            gun.ShotFired();
        }
        else
        {
            base.OnClick();
        }
    }
}
