using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShieldedBehaviour : TargetBehaviour
{
    private SpriteRenderer rendererRef;
    private bool hasShield = true;

    protected override void Start()
    {
        base.Start();
        rendererRef = GetComponent<SpriteRenderer>();
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
            rendererRef.color = new Color32(255, 255, 255, 255);
            gun.ShotFired();
        }
        else
        {
            base.OnClick();
        }
    }
}
